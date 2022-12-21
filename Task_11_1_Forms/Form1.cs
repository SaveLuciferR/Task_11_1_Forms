using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_11_1_Forms
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			textBox1.Text = "";
			textBox2.Text = "";
			textBox3.Text = "";
			textBox4.Text = "";
			textBox5.Text = "";
		}

		private void button2_Click(object sender, EventArgs e)
		{
			try
			{
				textBox4.Text = "";
				int n = Convert.ToInt32(textBox1.Text);
				int m = Convert.ToInt32(textBox2.Text);

				if (n < 1 || m < 1)
				{
					throw new Exception();
				}

				Array doubleArray = new Array(n, m);

				doubleArray.SetArrayElement(textBox3);
				textBox4.Text += "\r\n\r\n";
				doubleArray.GetArrayElement(textBox4);
				textBox4.Text += "\r\nСортировка массива\r\n";
				doubleArray.SortArrayElement();
				doubleArray.GetArrayElement(textBox4);
				int scalar = Convert.ToInt32(textBox5.Text);
				doubleArray.scalarArray = scalar;
				textBox4.Text += "\nМассив, умноженный на скаляр\r\n";
				doubleArray.GetArrayElement(textBox4);
				textBox4.Text += "\r\nКол-во элеметов в массиве: " + doubleArray.countArray + "\r\n";
			}
			catch (FormatException)
			{
				textBox4.Text = "Введите верный формат";
			}
			catch (IndexOutOfRangeException)
			{
				textBox4.Text = "Кол-во введенных элементлов в массив не совпадают с его размером";
			}
			catch
			{
				textBox4.Text = "Что-то пошло не так";
			}
		}
	}

	class Array
	{
		private double[][] doubleArray;
		private int n, m;

		public int countArray
		{
			get
			{
				return n * m;
			}
		}
		public int scalarArray
		{
			set
			{
				for (int i = 0; i < n; i++)
				{
					for (int j = 0; j < m; j++)
					{
						doubleArray[i][j] += value;
					}
				}
			}
		}

		public Array(int n, int m)
		{
			this.n = n;
			this.m = m;
			doubleArray = new double[n][];
			for (int i = 0; i < n; i++)
			{
				doubleArray[i] = new double[m];
			}
		}

		public void SetArrayElement(TextBox textBox)
		{
			string[] splitStr = textBox.Text.Split(' ');
			int index = 0;

			if (splitStr.Length != n * m)
			{
				throw new IndexOutOfRangeException();
			}
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < m; j++)
				{
					doubleArray[i][j] = Convert.ToDouble(splitStr[index]);
					index++;
				}
			}
		}

		public void GetArrayElement(TextBox textBox)
		{
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < m; j++)
				{
					textBox.Text += (doubleArray[i][j] + "\t");
				}
				textBox.Text += "\r\n\r\n";
			}
		}

		public void SortArrayElement()
		{
			for (int i = 0; i < n; i++)
			{
				for (int k = 0; k < m; k++)
				{
					for (int j = 0; j < m - 1; j++)
					{
						if (doubleArray[i][j] < doubleArray[i][j + 1])
						{
							double temp = doubleArray[i][j];
							doubleArray[i][j] = doubleArray[i][j + 1];
							doubleArray[i][j + 1] = temp;
						}
					}
				}
			}
		}
	}
}
