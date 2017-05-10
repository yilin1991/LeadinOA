<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Left.ascx.cs" Inherits="Leadin.OA.Controls.Left" %>

<div class="tpl-left-nav tpl-left-nav-hover">
    <div class="tpl-left-nav-title">
        Amaze UI 列表
    </div>
    <div class="tpl-left-nav-list">
        <ul class="tpl-left-nav-menu">
            <li class="tpl-left-nav-item">
                <a href="index.html" class="nav-link ">
                    <i class="am-icon-home"></i>
                    <span>首页</span>
                </a>
            </li>
            <li class="tpl-left-nav-item">
                <a class="nav-link tpl-left-nav-link-list">
                    <i class="am-icon-bar-chart"></i>
                    <span>类别管理</span>
                     <i class="am-icon-angle-right tpl-left-nav-more-ico am-fr am-margin-right"></i>
                </a>
                <ul class="tpl-left-nav-sub-menu">
                    <li>
                        <a href="/oasystem/oacategory/index.aspx">
                            <i class="am-icon-angle-right"></i>
                            <span>类别管理</span>
                        </a>

                        <a href="/oasystem/oacategory/edit.aspx">
                            <i class="am-icon-angle-right"></i>
                            <span>添加类别</span>
                        </a>

                </ul>
            </li>

            <li class="tpl-left-nav-item">
                <a href="javascript:;" class="nav-link tpl-left-nav-link-list">
                    <i class="am-icon-table"></i>
                    <span>表格</span>
                    <i class="am-icon-angle-right tpl-left-nav-more-ico am-fr am-margin-right"></i>
                </a>
                <ul class="tpl-left-nav-sub-menu">
                    <li>
                        <a href="table-font-list.html">
                            <i class="am-icon-angle-right"></i>
                            <span>文字表格</span>
                            <i class="am-icon-star tpl-left-nav-content-ico am-fr am-margin-right"></i>
                        </a>

                        <a href="table-images-list.html">
                            <i class="am-icon-angle-right"></i>
                            <span>图片表格</span>
                            <i class="tpl-left-nav-content tpl-badge-success">18
                            </i>
                        </a>
                        <a href="form-news.html">
                            <i class="am-icon-angle-right"></i>
                            <span>消息列表</span>
                            <i class="tpl-left-nav-content tpl-badge-primary">5
                            </i>
                        </a>

                        <a href="form-news-list.html">
                            <i class="am-icon-angle-right"></i>
                            <span>文字列表</span>

                        </a></li>
                </ul>
            </li>

            <li class="tpl-left-nav-item">
                <a href="javascript:;" class="nav-link tpl-left-nav-link-list">
                    <i class="am-icon-wpforms"></i>
                    <span>表单</span>
                    <i class="am-icon-angle-right tpl-left-nav-more-ico am-fr am-margin-right"></i>
                </a>
                <ul class="tpl-left-nav-sub-menu" >
                    <li>
                        <a href="form-amazeui.html">
                            <i class="am-icon-angle-right"></i>
                            <span>Amaze UI 表单</span>
                            <i class="am-icon-star tpl-left-nav-content-ico am-fr am-margin-right"></i>
                        </a>

                        <a href="form-line.html">
                            <i class="am-icon-angle-right"></i>
                            <span>线条表单</span>
                        </a>
                    </li>
                </ul>
            </li>

            <li class="tpl-left-nav-item">
                <a href="login.html" class="nav-link tpl-left-nav-link-list">
                    <i class="am-icon-key"></i>
                    <span>登录</span>

                </a>
            </li>
        </ul>
    </div>
</div>

