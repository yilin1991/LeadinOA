using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Leadin.OA.oasystem.oasystem
{
    public partial class edit : Leadin.Web.UI.ManagePage
    {

        BLL.Category bll = new BLL.Category();
        Model.Category model = new Model.Category();

        int id;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindddlType(0, ddlParentType);

                if (int.TryParse(Request.Params["id"], out id))
                {
                    BindDetail(id);
                }
            }
        }




        /// <summary>
        /// 绑定类别详细信息
        /// </summary>
        /// <param name="id">类别编号</param>
        void BindDetail(int id)
        {
            model = bll.GetModel(id);
            txtExplain.Text = model.Explain;
            txtSortNum.Text = model.SortNum.ToString();
            txtSubTitle.Text = model.SubTitle;
            txtTitle.Text = model.Title;
            ddlParentType.SelectedValue = model.ParentId.ToString();
            ckState.Checked = model.StateInfo == 1 ? true : false;
        }


        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnOK_Click(object sender, EventArgs e)
        {
            if (int.TryParse(Request.Params["id"], out id))
            {
                model = bll.GetModel(id);
            }


            model.ParentId = int.Parse(ddlParentType.SelectedValue);
            model.Remark = "";
            model.SortNum = int.Parse(txtSortNum.Text);
            model.StateInfo = ckState.Checked ? 1 : 0;
            model.SubTitle = txtSubTitle.Text;
            model.Title = txtTitle.Text;

            if (int.Parse(ddlParentType.SelectedValue) == 0)
            {
                model.LevelNum = 0;
            }
            else
            {
                model.LevelNum = bll.GetModel(int.Parse(ddlParentType.SelectedValue)).LevelNum + 1;
            }

            if (string.IsNullOrEmpty(model.Id.ToString()) || string.Equals(model.Id.ToString(), "0"))
            {
                model.NumId = bll.SetNumID();
                model.AddTime = DateTime.Now;

                if (bll.Add(model) > 0)
                {
                    JsMessage("类别添加成功", 2000, "true", "index.aspx");
                }
                else
                {
                    JsMessage("类别添加失败，请稍候重试", 2000, "false");
                }

            }
            else
            {

                if (bll.Update(model))
                {
                    JsMessage("类别信息修改成功", 2000, "true", "index.aspx" + Request.Url.Query);
                }
                else
                {
                    JsMessage("类别信息修改失败，请稍候重试", 2000, "false");
                }

            }



        }
    }
}