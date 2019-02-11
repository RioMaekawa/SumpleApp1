using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms_DivisionApp
{
    public partial class Form1 : Form
    {
        private string before_TotalPrice;
        private string before_Ninzu;

        public Form1()
        {
            InitializeComponent();
        }

        //初期起動時、ボタンは非活性
        private void Form1_Load(object sender, EventArgs e)
        {
            btnCalculate.Enabled = false;
            Resetbtn.Enabled = false;
        }


        //計算ボタンのイベント処理
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            //入力された文字を数字に変換
            int sumPrice = int.Parse(txtTotalPrice.Text);
            int Ninzu = int.Parse(txtNinzu.Text);

            //割り算結果の数字を文字に変換し出力
            txtWari.Text = (sumPrice / Ninzu).ToString();

            Resetbtn.Enabled = true;
        }

        //合計金額テキストのイベント処理
        private void txtWari_TextChanged(object sender, EventArgs e)
        {
            int i = 0;

            //合計金額入力時、合計金額テキストボックスに入力データをセット
            if (int.TryParse(txtTotalPrice.Text, out i) == false && (txtTotalPrice.Text != ""))
            {

                txtTotalPrice.Text = before_TotalPrice;
            }

            before_TotalPrice = txtTotalPrice.Text;

            btnaction();
        }

        //計算ボタンの活性・非活性化のイベント処理
        private void btnaction()
        {
            //合計金額および人数テキストが入力済の場合、計算ボタンを活性化
            if (txtTotalPrice.Text != "" && txtNinzu.Text != "")
            {
                btnCalculate.Enabled = true;
            }
            else
            {
                btnCalculate.Enabled = false;
            }

        }

        //人数テキストのイベント処理
        private void txtNinzu_TextChanged(object sender, EventArgs e)
        {
            int i = 0;

            //人数入力時、人数テキストボックスに入力データをセット
            if (int.TryParse(txtNinzu.Text, out i) == false && (txtNinzu.Text != ""))
            {
                txtNinzu.Text = before_Ninzu;
            }

            before_Ninzu = txtNinzu.Text;

            btnaction();
        }

        //リセットボタンのイベント処理
        private void Resetbtn_Click(object sender, EventArgs e)
        {
            txtTotalPrice.Clear();
            txtNinzu.Clear();
            txtWari.Text = String.Empty;

            Resetbtn.Enabled = false;
        }
    }
}
