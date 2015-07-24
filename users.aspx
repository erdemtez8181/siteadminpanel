<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="users.aspx.cs" Inherits="AdminPanel.users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-content" style="min-height: 1119px">
        <!-- BEGIN SAMPLE PORTLET CONFIGURATION MODAL FORM-->
        <div class="modal fade" id="portlet-config" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                        <h4 class="modal-title">Modal title</h4>
                    </div>
                    <div class="modal-body">
                        Widget settings form goes here
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn blue">Save changes</button>
                        <button type="button" class="btn default" data-dismiss="modal">Close</button>
                    </div>
                </div>
                <!-- /.modal-content -->
            </div>
            <!-- /.modal-dialog -->
        </div>
        <!-- /.modal -->
        <!-- END SAMPLE PORTLET CONFIGURATION MODAL FORM-->
        <!-- BEGIN STYLE CUSTOMIZER -->
        <div class="theme-panel hidden-xs hidden-sm">
            <div class="toggler">
            </div>
            <div class="toggler-close">
            </div>
            <div class="theme-options">
                <div class="theme-option theme-colors clearfix">
                    <span>THEME COLOR </span>
                    <ul>
                        <li class="color-default current tooltips" data-style="default" data-container="body" data-original-title="Default"></li>
                        <li class="color-darkblue tooltips" data-style="darkblue" data-container="body" data-original-title="Dark Blue"></li>
                        <li class="color-blue tooltips" data-style="blue" data-container="body" data-original-title="Blue"></li>
                        <li class="color-grey tooltips" data-style="grey" data-container="body" data-original-title="Grey"></li>
                        <li class="color-light tooltips" data-style="light" data-container="body" data-original-title="Light"></li>
                        <li class="color-light2 tooltips" data-style="light2" data-container="body" data-html="true" data-original-title="Light 2"></li>
                    </ul>
                </div>
                <div class="theme-option">
                    <span>Theme Style </span>
                    <select class="layout-style-option form-control input-sm">
                        <option value="square" selected="selected">Square corners</option>
                        <option value="rounded">Rounded corners</option>
                    </select>
                </div>
                <div class="theme-option">
                    <span>Layout </span>
                    <select class="layout-option form-control input-sm">
                        <option value="fluid" selected="selected">Fluid</option>
                        <option value="boxed">Boxed</option>
                    </select>
                </div>
                <div class="theme-option">
                    <span>Header </span>
                    <select class="page-header-option form-control input-sm">
                        <option value="fixed" selected="selected">Fixed</option>
                        <option value="default">Default</option>
                    </select>
                </div>
                <div class="theme-option">
                    <span>Top Menu Dropdown</span>
                    <select class="page-header-top-dropdown-style-option form-control input-sm">
                        <option value="light" selected="selected">Light</option>
                        <option value="dark">Dark</option>
                    </select>
                </div>
                <div class="theme-option">
                    <span>Sidebar Mode</span>
                    <select class="sidebar-option form-control input-sm">
                        <option value="fixed">Fixed</option>
                        <option value="default" selected="selected">Default</option>
                    </select>
                </div>
                <div class="theme-option">
                    <span>Sidebar Menu </span>
                    <select class="sidebar-menu-option form-control input-sm">
                        <option value="accordion" selected="selected">Accordion</option>
                        <option value="hover">Hover</option>
                    </select>
                </div>
                <div class="theme-option">
                    <span>Sidebar Style </span>
                    <select class="sidebar-style-option form-control input-sm">
                        <option value="default" selected="selected">Default</option>
                        <option value="light">Light</option>
                    </select>
                </div>
                <div class="theme-option">
                    <span>Sidebar Position </span>
                    <select class="sidebar-pos-option form-control input-sm">
                        <option value="left" selected="selected">Left</option>
                        <option value="right">Right</option>
                    </select>
                </div>
                <div class="theme-option">
                    <span>Footer </span>
                    <select class="page-footer-option form-control input-sm">
                        <option value="fixed">Fixed</option>
                        <option value="default" selected="selected">Default</option>
                    </select>
                </div>
            </div>
        </div>
        <!-- END STYLE CUSTOMIZER -->
        <!-- BEGIN PAGE HEADER-->
        <h3 class="page-title">Editable Datatables <small>editable datatable samples</small>
        </h3>
        <div class="page-bar">
            <ul class="page-breadcrumb">
                <li>
                    <i class="fa fa-home"></i>
                    <a href="index.html">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Data Tables</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Editable Datatables</a>
                </li>
            </ul>
            <div class="page-toolbar">
                <div class="btn-group pull-right">
                    <button type="button" class="btn btn-fit-height grey-salt dropdown-toggle" data-toggle="dropdown" data-hover="dropdown" data-delay="1000" data-close-others="true">
                        Actions <i class="fa fa-angle-down"></i>
                    </button>
                    <ul class="dropdown-menu pull-right" role="menu">
                        <li>
                            <a href="#">Action</a>
                        </li>
                        <li>
                            <a href="#">Another action</a>
                        </li>
                        <li>
                            <a href="#">Something else here</a>
                        </li>
                        <li class="divider"></li>
                        <li>
                            <a href="#">Separated link</a>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
        <!-- END PAGE HEADER-->
        <!-- BEGIN PAGE CONTENT-->
        <div class="row">
            <div class="col-md-12">
                <!-- BEGIN EXAMPLE TABLE PORTLET-->
                <div class="portlet box blue">
                    <div class="portlet-title">
                        <div class="caption">
                            <i class="fa fa-edit"></i>Editable Table
                        </div>
                        <div class="tools">
                            <a href="javascript:;" class="collapse" data-original-title="" title=""></a>
                            <a href="#portlet-config" data-toggle="modal" class="config" data-original-title="" title=""></a>
                            <a href="javascript:;" class="reload" data-original-title="" title=""></a>
                            <a href="javascript:;" class="remove" data-original-title="" title=""></a>
                        </div>
                    </div>
                    <div class="portlet-body">
                        <div class="table-toolbar">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="btn-group">
                                        <button id="sample_editable_1_new" class="btn green">
                                            Add New <i class="fa fa-plus"></i>
                                        </button>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="btn-group pull-right">
                                        <button class="btn dropdown-toggle" data-toggle="dropdown">
                                            Tools <i class="fa fa-angle-down"></i>
                                        </button>
                                        <ul class="dropdown-menu pull-right">
                                            <li>
                                                <a href="javascript:;">Print </a>
                                            </li>
                                            <li>
                                                <a href="javascript:;">Save as PDF </a>
                                            </li>
                                            <li>
                                                <a href="javascript:;">Export to Excel </a>
                                            </li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="sample_editable_1_wrapper" class="dataTables_wrapper no-footer">
                            <div class="row">
                                <div class="col-md-6 col-sm-6">
                                    <div class="dataTables_length" id="sample_editable_1_length">
                                        <label>
                                            <div class="select2-container form-control input-xsmall input-inline" id="s2id_autogen1"><a href="javascript:void(0)" class="select2-choice" tabindex="-1"><span class="select2-chosen" id="select2-chosen-2">5</span><abbr class="select2-search-choice-close"></abbr>
                                                <span class="select2-arrow" role="presentation"><b role="presentation"></b></span></a>
                                                <label for="s2id_autogen2" class="select2-offscreen"></label>
                                                <input class="select2-focusser select2-offscreen" type="text" aria-haspopup="true" role="button" aria-labelledby="select2-chosen-2" id="s2id_autogen2"><div class="select2-drop select2-display-none select2-with-searchbox">
                                                    <div class="select2-search">
                                                        <label for="s2id_autogen2_search" class="select2-offscreen"></label>
                                                        <input type="text" autocomplete="off" autocorrect="off" autocapitalize="off" spellcheck="false" class="select2-input" role="combobox" aria-expanded="true" aria-autocomplete="list" aria-owns="select2-results-2" id="s2id_autogen2_search" placeholder="">
                                                    </div>
                                                    <ul class="select2-results" role="listbox" id="select2-results-2"></ul>
                                                </div>
                                            </div>
                                            <select name="sample_editable_1_length" aria-controls="sample_editable_1" class="form-control input-xsmall input-inline select2-offscreen" tabindex="-1" title="">
                                                <option value="5">5</option>
                                                <option value="15">15</option>
                                                <option value="20">20</option>
                                                <option value="-1">All</option>
                                            </select>
                                            records</label></div>
                                </div>
                                <div class="col-md-6 col-sm-6">
                                    <div id="sample_editable_1_filter" class="dataTables_filter">
                                        <label>Search:<input type="search" class="form-control input-small input-inline" placeholder="" aria-controls="sample_editable_1"></label></div>
                                </div>
                            </div>
                            <div class="table-scrollable">
                                <table class="table table-striped table-hover table-bordered dataTable no-footer" id="sample_editable_1" role="grid" aria-describedby="sample_editable_1_info" style="width: 1604px;">
                                    <thead>
                                        <tr role="row">
                                            <th class="sorting_asc" tabindex="0" aria-controls="sample_editable_1" rowspan="1" colspan="1" aria-label="
									 Username
								: activate to sort column ascending"
                                                style="width: 287px;" aria-sort="ascending">Username
                                            </th>
                                            <th class="sorting" tabindex="0" aria-controls="sample_editable_1" rowspan="1" colspan="1" aria-label="
									 Full Name
								: activate to sort column ascending"
                                                style="width: 358px;">Full Name
                                            </th>
                                            <th class="sorting" tabindex="0" aria-controls="sample_editable_1" rowspan="1" colspan="1" aria-label="
									 Points
								: activate to sort column ascending"
                                                style="width: 200px;">Points
                                            </th>
                                            <th class="sorting" tabindex="0" aria-controls="sample_editable_1" rowspan="1" colspan="1" aria-label="
									 Notes
								: activate to sort column ascending"
                                                style="width: 251px;">Notes
                                            </th>
                                            <th class="sorting" tabindex="0" aria-controls="sample_editable_1" rowspan="1" colspan="1" aria-label="
									 Edit
								: activate to sort column ascending"
                                                style="width: 145px;">Edit
                                            </th>
                                            <th class="sorting" tabindex="0" aria-controls="sample_editable_1" rowspan="1" colspan="1" aria-label="
									 Delete
								: activate to sort column ascending"
                                                style="width: 202px;">Delete
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody>






                                        <tr role="row" class="odd">
                                            <td class="sorting_1">alex
                                            </td>
                                            <td>Alex Nilson
                                            </td>
                                            <td>1234
                                            </td>
                                            <td class="center">power user
                                            </td>
                                            <td>
                                                <a class="edit" href="javascript:;">Edit </a>
                                            </td>
                                            <td>
                                                <a class="delete" href="javascript:;">Delete </a>
                                            </td>
                                        </tr>
                                        <tr role="row" class="even">
                                            <td class="sorting_1">gist124
                                            </td>
                                            <td>Nick Roberts
                                            </td>
                                            <td>62
                                            </td>
                                            <td class="center">new user
                                            </td>
                                            <td>
                                                <a class="edit" href="javascript:;">Edit </a>
                                            </td>
                                            <td>
                                                <a class="delete" href="javascript:;">Delete </a>
                                            </td>
                                        </tr>
                                        <tr role="row" class="odd">
                                            <td class="sorting_1">goldweb
                                            </td>
                                            <td>Sergio Jackson
                                            </td>
                                            <td>132
                                            </td>
                                            <td class="center">elite user
                                            </td>
                                            <td>
                                                <a class="edit" href="javascript:;">Edit </a>
                                            </td>
                                            <td>
                                                <a class="delete" href="javascript:;">Delete </a>
                                            </td>
                                        </tr>
                                        <tr role="row" class="even">
                                            <td class="sorting_1">lisa
                                            </td>
                                            <td>Lisa Wong
                                            </td>
                                            <td>434
                                            </td>
                                            <td class="center">new user
                                            </td>
                                            <td>
                                                <a class="edit" href="javascript:;">Edit </a>
                                            </td>
                                            <td>
                                                <a class="delete" href="javascript:;">Delete </a>
                                            </td>
                                        </tr>
                                        <tr role="row" class="odd">
                                            <td class="sorting_1">nick12
                                            </td>
                                            <td>Nick Roberts
                                            </td>
                                            <td>232
                                            </td>
                                            <td class="center">power user
                                            </td>
                                            <td>
                                                <a class="edit" href="javascript:;">Edit </a>
                                            </td>
                                            <td>
                                                <a class="delete" href="javascript:;">Delete </a>
                                            </td>
                                        </tr>
                                        <tr role="row" class="even">
                                            <td class="sorting_1">sdf</td>
                                            <td>sdfsdf</td>
                                            <td>sdfs</td>
                                            <td>sdfsdf</td>
                                            <td><a class="edit" href="">Edit</a></td>
                                            <td><a class="delete" href="">Delete</a></td>
                                        </tr>
                                        <tr role="row" class="odd">
                                            <td class="sorting_1">webriver
                                            </td>
                                            <td>Antonio Sanches
                                            </td>
                                            <td>462
                                            </td>
                                            <td class="center">new user
                                            </td>
                                            <td>
                                                <a class="edit" href="javascript:;">Edit </a>
                                            </td>
                                            <td>
                                                <a class="delete" href="javascript:;">Delete </a>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                            <div class="row">
                                <div class="col-md-5 col-sm-5">
                                    <div class="dataTables_info" id="sample_editable_1_info" role="status" aria-live="polite">Showing 1 to 7 of 7 entries</div>
                                </div>
                                <div class="col-md-7 col-sm-7">
                                    <div class="dataTables_paginate paging_simple_numbers" id="sample_editable_1_paginate">
                                        <ul class="pagination">
                                            <li class="paginate_button previous disabled" aria-controls="sample_editable_1" tabindex="0" id="sample_editable_1_previous"><a href="#"><i class="fa fa-angle-left"></i></a></li>
                                            <li class="paginate_button active" aria-controls="sample_editable_1" tabindex="0"><a href="#">1</a></li>
                                            <li class="paginate_button next disabled" aria-controls="sample_editable_1" tabindex="0" id="sample_editable_1_next"><a href="#"><i class="fa fa-angle-right"></i></a></li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- END EXAMPLE TABLE PORTLET-->
            </div>
        </div>
        <!-- END PAGE CONTENT -->
    </div>

</asp:Content>
