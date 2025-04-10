using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab5_6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var copybook = new Copybook("Lab 5-6", 60, true, new List<string> { "Note 1", "Note 2" });
            ReflectionMethod.DisplayClassInfoInTreeView(copybook, treeView1);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
        }
    }

    public static class ReflectionMethod
    {
        public static void DisplayClassInfoInTreeView(object obj, System.Windows.Forms.TreeView treeView)
        {
            treeView.Nodes.Clear();

            if (obj == null) return;

            Type type = obj.GetType();
            TreeNode classNode = new TreeNode(type.Name);
            treeView.Nodes.Add(classNode);

            // Properties
            TreeNode propertiesNode = new TreeNode("Properties");
            classNode.Nodes.Add(propertiesNode);

            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                object value = property.GetValue(obj, null);
                string displayValue = value is System.Collections.IEnumerable && !(value is string)
                    ? "(Collection)"
                    : value?.ToString() ?? "null";

                TreeNode propertyNode = new TreeNode($"{property.PropertyType.Name} {property.Name} = {displayValue}");
                propertiesNode.Nodes.Add(propertyNode);

                if (value is System.Collections.IEnumerable collection && !(value is string))
                {
                    foreach (var item in collection)
                    {
                        propertyNode.Nodes.Add(new TreeNode(item?.ToString() ?? "null"));
                    }
                }
            }

            // Constructors
            TreeNode constructorsNode = new TreeNode("Constructors");
            classNode.Nodes.Add(constructorsNode);

            ConstructorInfo[] constructors = type.GetConstructors();
            foreach (ConstructorInfo ctor in constructors)
            {
                string ctorSignature = $"{type.Name}(";
                ParameterInfo[] parameters = ctor.GetParameters();
                ctorSignature += string.Join(", ", parameters.Select(p => $"{p.ParameterType.Name} {p.Name}"));
                ctorSignature += ")";
                constructorsNode.Nodes.Add(new TreeNode(ctorSignature));
            }

            // Methods
            TreeNode methodsNode = new TreeNode("Methods");
            classNode.Nodes.Add(methodsNode);

            MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            foreach (MethodInfo method in methods)
            {
                string methodSignature = $"{method.ReturnType.Name} {method.Name}(";
                ParameterInfo[] parameters = method.GetParameters();
                methodSignature += string.Join(", ", parameters.Select(p => $"{p.ParameterType.Name} {p.Name}"));
                methodSignature += ")";
                methodsNode.Nodes.Add(new TreeNode(methodSignature));
            }

            classNode.ExpandAll();
        }
    }
}