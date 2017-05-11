using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Leadin.OA.oasystem.oapaper
{
    public partial class edit : Leadin.Web.UI.ManagePage
    {
        BLL.Paper bll = new BLL.Paper();
        Model.Paper model = new Model.Paper();
        public string NumIdUrl = "/Tools/CheckPaperNumId.ashx";
        public string numId;


        int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (int.TryParse(Request.Params["id"], out id))
                {
                    BindDetail(id);
                }
            }
        }

        /// <summary>
        /// 纸张详细信息 
        /// </summary>
        /// <param name="id"></param>
        void BindDetail(int id)
        {
            model = bll.GetModel(id);
            txtNameInfo.Text = model.NameInfo;
            txtNum.Text = model.Num.ToString();
            numId = model.NumId;
            txtPaperSpec.Text = model.PaperSpec;
            txtPrice.Text = model.Price.ToString("0.00");
            txtSortNum.Text = model.SortNum.ToString();
            ckState.Checked = model.StateInfo == 1 ? true : false;
            NumIdUrl = "";





        }


        /// <summary>
        /// 确认提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnOK_Click(object sender, EventArgs e)
        {
            bool isEdit = false;
            if (int.TryParse(Request.Params["id"], out id))
            {
                model = bll.GetModel(id);
                isEdit = true;
            }

            model.NameInfo = txtNameInfo.Text;
            model.Num = int.Parse(txtNum.Text);
            model.NumId = Request.Form["txtNumId"].ToString();
            model.PaperSpec = txtPaperSpec.Text;
            model.Price = decimal.Parse(txtPrice.Text);
            model.SortNum = int.Parse(txtSortNum.Text);
            model.StateInfo = ckState.Checked ? 1 : 0;

            if (isEdit)
            {
                if (bll.Update(model))
                {
                    JsMessage("纸张信息修改成功", 2000, "true", "index.aspx" + Request.Url.Query);
                }
                else
                {
                    JsMessage("纸张信息修改失败，请稍候重试", 2000, "false");
                }
            }
            else
            {
                if (bll.Add(model) > 0)
                {
                    JsMessage("纸张信息录入成功", 2000, "true", "index.aspx");
                }
                else
                {
                    JsMessage("纸张信息录入失败，请稍候重试", 2000, "false");
                }
            }



        }
    }
}