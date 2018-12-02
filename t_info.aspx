<%@ Page Title="" Language="C#" MasterPageFile="main.master" AutoEventWireup="true" CodeFile="t_info.aspx.cs" Inherits="t_info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Enter Traveller Information - Bahria Airways</title>
     <link href=" plugins/bower_components/jquery-wizard-master/css/wizard.css" rel="stylesheet">
      <link rel="stylesheet" href=" plugins/bower_components/jquery-wizard-master/libs/formvalidation/formValidation.min.css">
    <link href="plugins/bower_components/bootstrap-datepicker/bootstrap-datepicker.min.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div class="container-fluid">
                <div class="row bg-title">
                    <div class="col-lg-3 col-md-4 col-sm-4 col-xs-12">
                        <h4 class="page-title">Enter Traveller Information</h4> </div>
                    <%--  --%>
                    <!-- /.col-lg-12 -->
                </div>
             
<div class="row">
                    <div class="col-lg-12">
                        <div class="white-box">
                            <h3 class="box-title m-b-0">Enter Traveller Information</h3>
                            <br />
                                <form runat="server" class="form-horizontal">
                                     <div style='border-bottom: 0px solid #000'>
                                        
                                    <asp:Panel ID="pnlTextBoxes" runat="server" Visible="true">
                                       
                                            
                                        
                                         
                                       
                                             
                                    </asp:Panel>
                                             
                                  </div>
                                    <asp:Button class="btn btn-success" ID="Button1" runat="server" Text="Continue" OnClick="Button1_Click" />
                                </form>
                        </div>
                        </div>
    </div>
          </div>
     <script src=" plugins/bower_components/jquery-wizard-master/dist/jquery-wizard.min.js"></script>
    <script src=" plugins/bower_components/jquery-wizard-master/libs/formvalidation/formValidation.min.js"></script>
    <script src=" plugins/bower_components/jquery-wizard-master/libs/formvalidation/bootstrap.min.js"></script>
        <script src="plugins/bower_components/bootstrap-select/bootstrap-select.min.js"></script>
    <script src="plugins/bower_components/footable/js/footable.all.min.js"></script>
     <script src="plugins/bower_components/clockpicker/dist/jquery-clockpicker.min.js"></script>
    <script src="plugins/bower_components/bootstrap-datepicker/bootstrap-datepicker.min.js"></script>
      <script>
        jQuery('#exampleBasic').wizard({
            onFinish: function () {
                alert('finish');
            }
        });
        var dateToday = new Date();

        jQuery('.mydatepicker, #datepicker').datepicker({
            dateFormat: 'yy-mm-dd',
            autoclose: true,
            todayHighlight: true,
            format: 'yyyy-mm-dd',


            // appendText: "(yyyy-mm-dd)"
        });
    
    </script>
</asp:Content>

