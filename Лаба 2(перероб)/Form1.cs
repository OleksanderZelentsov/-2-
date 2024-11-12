using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace Лаба_2_перероб_
{
    public partial class Form1 : Form
    {
        private Graph UndirectedGraph;
        private Graph DirectedGraph;

        public Form1()
        {
            InitializeComponent();

            UndirectedGraph = new Graph(9);
            UndirectedGraph.AddEdgeUndirected(0, 1);
            UndirectedGraph.AddEdgeUndirected(0, 3);
            UndirectedGraph.AddEdgeUndirected(1, 3);
            UndirectedGraph.AddEdgeUndirected(1, 4);
            UndirectedGraph.AddEdgeUndirected(1, 5);
            UndirectedGraph.AddEdgeUndirected(2, 2);
            UndirectedGraph.AddEdgeUndirected(2, 3);
            UndirectedGraph.AddEdgeUndirected(2, 4);
            UndirectedGraph.AddEdgeUndirected(2, 5);

            DirectedGraph = new Graph(12);
            DirectedGraph.AddEdgeDirected(0, 1);
            DirectedGraph.AddEdgeDirected(0, 3);
            DirectedGraph.AddEdgeDirected(0, 4);
            DirectedGraph.AddEdgeDirected(1, 2);
            DirectedGraph.AddEdgeDirected(1, 3);
            DirectedGraph.AddEdgeDirected(1, 4);
            DirectedGraph.AddEdgeDirected(1, 5);
            DirectedGraph.AddEdgeDirected(2, 4);
            DirectedGraph.AddEdgeDirected(2, 5);
            DirectedGraph.AddEdgeDirected(3, 2);
            DirectedGraph.AddEdgeDirected(3, 4);
            DirectedGraph.AddEdgeDirected(4, 5);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = comboBox1.SelectedItem.ToString();
            if (selectedItem == "Орієнтований граф")
            {
                string basePath = System.Windows.Forms.Application.StartupPath;
                pictureBox1.Image = System.Drawing.Image.FromFile(System.IO.Path.Combine(basePath, @"images\орг.jpg"));
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                string basePath = System.Windows.Forms.Application.StartupPath;
                pictureBox1.Image = System.Drawing.Image.FromFile(System.IO.Path.Combine(basePath, @"images\неорг.jpg"));
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string result = string.Empty;

            
            if (comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Будь ласка, введіть вершину!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }

            
            string graphType = comboBox1.SelectedItem?.ToString();
            Graph graphToUse = graphType == "Орієнтований граф" ? DirectedGraph : UndirectedGraph;

           
            Dictionary<string, int> vertexMap = new Dictionary<string, int>
    {
        { "a", 0 },
        { "b", 1 },
        { "c", 2 },
        { "d", 3 },
        { "e", 4 },
        { "f", 5 }
    };

            
            Dictionary<int, string> reverseVertexMap = vertexMap.ToDictionary(kvp => kvp.Value, kvp => kvp.Key);

            
            string selectedVertex = comboBox2.SelectedItem.ToString();

            
            if (vertexMap.TryGetValue(selectedVertex, out int startVertex))
            {
                
                richTextBox1.Clear();

                
                var dfsResult = graphToUse.DFS(startVertex);

               
                foreach (var vertex in dfsResult)
                {
                    if (reverseVertexMap.TryGetValue(vertex, out string vertexLetter))
                    {
                        result += vertexLetter + " ";
                    }
                }
                richTextBox1.AppendText("Обхід графа у глибину" + Environment.NewLine);
                richTextBox1.AppendText("DFS: " + result.Trim() + Environment.NewLine);
            }
            else
            {
                MessageBox.Show("Невірна вершина!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string result = string.Empty;

        
            if (comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Будь ласка, введіть вершину!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }

            
            string graphType = comboBox1.SelectedItem?.ToString();
            Graph graphToUse = graphType == "Орієнтований граф" ? DirectedGraph : UndirectedGraph;

            
            Dictionary<string, int> vertexMap = new Dictionary<string, int>
    {
        { "a", 0 },
        { "b", 1 },
        { "c", 2 },
        { "d", 3 },
        { "e", 4 },
        { "f", 5 }
    };

            
            Dictionary<int, string> reverseVertexMap = vertexMap.ToDictionary(kvp => kvp.Value, kvp => kvp.Key);

            
            string selectedVertex = comboBox2.SelectedItem.ToString();

            
            if (vertexMap.TryGetValue(selectedVertex, out int startVertex))
            {
                
                richTextBox1.Clear();

                
                var dfsResult = graphToUse.BFS(startVertex);

                
                foreach (var vertex in dfsResult)
                {
                    if (reverseVertexMap.TryGetValue(vertex, out string vertexLetter))
                    {
                        result += vertexLetter + " ";
                    }
                }
                richTextBox1.AppendText("Обхід графа у ширину" + Environment.NewLine);
                richTextBox1.AppendText("BFS: " + result.Trim() + Environment.NewLine);
            }
            else
            {
                MessageBox.Show("Невірна вершина!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }
        }
    }
}
