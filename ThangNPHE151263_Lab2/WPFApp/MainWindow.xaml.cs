using BusinessObjects.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IProductService iProductService;
        private readonly ICatergoryService iCatergoryService;
        public MainWindow()
        {
            InitializeComponent();
            iProductService = new ProductService();
            iCatergoryService = new CategoryService();
        }
        public void loadCategoryList()
        {
            try
            {
                var caList = iCatergoryService.GetCategories();
                cboCategory.ItemsSource = caList;
                cboCategory.DisplayMemberPath = "CategoryName";
                cboCategory.SelectedValuePath = "CategoryId";
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Err");
            }
        }
        public void loadProductList()
        {
            try
            {
                var productList = iProductService.GetProducts();
                dgData.ItemsSource = productList;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Err");
            }
            finally
            {
                resetInput();
            }
        }

        private void resetInput()
        {
            txtProductID.Text = "";
            txtProductName.Text = "";
            txtPrice.Text = "";
            txtUnitsInStock.Text = "";
            cboCategory.SelectedValue = 0;
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product p = new Product();
                p.ProductName = txtProductName.Text;
                p.UnitPrice = Decimal.Parse(txtPrice.Text);
                p.UnitsInStock = short.Parse(txtUnitsInStock.Text);
                p.CategoryId = Int32.Parse(cboCategory.SelectedValue.ToString());
                iProductService.SaveProduct(p);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                loadProductList();
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtProductID.Text.Length > 0)
                {
                    Product p = new Product();
                    p.ProductId = Int32.Parse(txtProductID.Text);
                    p.ProductName = txtProductName.Text;
                    p.UnitPrice = Decimal.Parse(txtPrice.Text);
                    p.UnitsInStock = short.Parse(txtUnitsInStock.Text);
                    p.CategoryId = Int32.Parse(cboCategory.SelectedValue.ToString());
                    iProductService.UpdateProduct(p);

                }
                else
                {
                    MessageBox.Show("err");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                loadProductList();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtProductID.Text.Length > 0)
                {
                    int ProductId = Int32.Parse(txtProductID.Text);
                    Product p = iProductService.GetProdctById(ProductId);
                    if (p != null)
                    {
                        iProductService.DeleteProduct(p);
                    }
                    else
                    {
                        MessageBox.Show("ProductNotfound");
                    }
                }
                else
                {
                    MessageBox.Show("err");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                loadProductList();
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            loadCategoryList();
            loadProductList();
        }
        private void dgData_SelectionChanged(object sender, RoutedEventArgs e)
        {
            DataGrid? dataGrid = sender as DataGrid;
            DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);
            DataGridCell? Rowcolum = dataGrid.Columns[0].GetCellContent(row).Parent as DataGridCell;
            string id = ((TextBlock)Rowcolum.Content).Text;
            try
            {
                Product product = iProductService.GetProdctById(Int32.Parse(id));
                txtProductID.Text = product.ProductId.ToString();
                txtProductName.Text = product.ProductName;
                txtPrice.Text = product.UnitPrice.ToString();
                txtUnitsInStock.Text = product.UnitsInStock.ToString();
                cboCategory.SelectedValue = product.CategoryId;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
