using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Leadin.OA.oasystem.oadstribution
{
    public partial class edit : Leadin.Web.UI.ManagePage
    {
        BLL.Distribution bll = new BLL.Distribution();
        Model.Distribution model = new Model.Distribution();
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
        /// 绑定合作快递详细信息
        /// </summary>
        /// <param name="id"></param>
        void BindDetail(int id)
        {
            model = bll.GetModel(id);
            txtCompanyName.Text = model.CompanyName;
            txtNameInfo.Text = model.NameInfo;
            txtPhone.Text = model.ContactTel;
            txtPrice.Text = ((decimal)model.Price).ToString("0.00");
            txtSortNum.Text = model.SortNum.ToString();
            ckState.Checked = model.StateInfo == 1 ? true : false;
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

            model.CompanyName = txtCompanyName.Text;
            model.ContactTel = txtPhone.Text;
            model.NameInfo = txtNameInfo.Text;
            model.Price = decimal.Parse(txtPrice.Text);
            model.SortNum = int.Parse(txtSortNum.Text);
            model.StateInfo = ckState.Checked ? 1 : 0;


            if (!isEdit)
            {
                if (bll.Add(model) > 0)
                {
                    JsMessage("合作快递添加成功", 2000, "true", "index.aspx");
                }
                else
                {
                    JsMessage("合作快递添加失败，请稍候重试", 2000, "false");
                }
            }
            else
            {
                if (bll.Update(model))
                {
                    JsMessage("合作快递信息修改成功", 2000, "true", "index.aspx" + Request.Url.Query);
                }
                else
                {
                    JsMessage("合作快递信息修改失败，请稍候重试", 2000, "false");
                }
            }






        }
    }
}