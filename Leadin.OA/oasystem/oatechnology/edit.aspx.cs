using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Leadin.OA.oasystem.oatechnology
{
    public partial class edit : Leadin.Web.UI.ManagePage
    {
        BLL.Technology bll = new BLL.Technology();
        Model.Technology model = new Model.Technology();

        int id;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindParentCompany();
                if (int.TryParse(Request.Params["id"], out id))
                {
                    BindDetail(id);
                }
            }
        }



        /// <summary>
        /// 绑定直接客户
        /// </summary>
        void BindParentCompany()
        {
            DataSet ds = bll.GetList(0, "ParentId=0 and StateInfo=1", "SortNum desc, AddTime asc");

            foreach (DataRow item in ds.Tables[0].Rows)
            {
                ListItem list = new ListItem();
                list.Text = item["NameInfo"].ToString();
                list.Value = item["Id"].ToString();
                ddlTechnology.Items.Add(list);

            }
        }



        /// <summary>
        /// 绑定供应商详细信息
        /// </summary>
        /// <param name="id"></param>
        void BindDetail(int id)
        {
            model = bll.GetModel(id);
            txtPrice.Text =((decimal) model.Price).ToString("0.00");
            //txtTemPrice.Text = ((decimal)model.Price).ToString("0.00");
            txtRemark.Text = model.Remark;
            txtSortNum.Text = model.SortNum.ToString();
            txtTitle.Text = model.NameInfo;
            ckState.Checked = model.StateInfo == 1 ? true : false;
            ddlTechnology.SelectedValue = model.ParentId.ToString();
        }


        /// <summary>
        /// 提交
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
            else
            {
                model.NumId = bll.SetNumID();
                model.AddTime = DateTime.Now;
            }


            model.NameInfo = txtTitle.Text;
            model.ParentId = int.Parse(ddlTechnology.SelectedValue);
            model.Price = decimal.Parse(txtPrice.Text);
            model.Remark = txtRemark.Text;
            model.SortNum = int.Parse(txtSortNum.Text);
            model.StateInfo = ckState.Checked ? 1 : 0;
            //model.TemPrice = decimal.Parse(txtTemPrice.Text);
            if (isEdit)
            {
                if (bll.Update(model))
                {
                    JsMessage("工艺信息修改成功", 2000, "true", "index.aspx" + Request.Url.Query);
                }
                else
                {
                    JsMessage("工艺信息修改失败，请稍候重试", 2000, "false");
                }
            }
            else
            {
                if (bll.Add(model) > 0)
                {
                    JsMessage("工艺信息录入成功", 2000, "true", "index.aspx");
                }
                else
                {
                    JsMessage("工艺信息录入失败，请稍候重试", 2000, "false");
                }
            }

        }
    }
}