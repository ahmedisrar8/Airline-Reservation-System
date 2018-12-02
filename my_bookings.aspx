<%@ Page Title="" Language="C#" MasterPageFile="main.master" AutoEventWireup="true" CodeFile="my_bookings.aspx.cs" Inherits="view_schedule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>View Bookings - Bahria Airways</title>
       <link href="plugins/bower_components/bootstrap-datepicker/bootstrap-datepicker.min.css" rel="stylesheet" type="text/css" />
    <link href="plugins/bower_components/footable/css/footable.core.css" rel="stylesheet" />
    <link href="plugins/bower_components/bootstrap-select/bootstrap-select.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-fluid">
                <div class="row bg-title">
                    <div class="col-lg-3 col-md-4 col-sm-4 col-xs-12">
                        <h4 class="page-title">My Bookings</h4> </div>
                    <%--  --%>
                    <!-- /.col-lg-12 -->
                </div>
             
<div class="row">
                    <div class="col-lg-12">
                        <div class="white-box">
                            <h3 class="box-title m-b-0">My Flights</h3>
                           
                          
                            <table id="demo-foo-row-toggler" class="table toggle-circle table-hover">
                              
                                  <thead>
                                    <tr>
                                        <th data-toggle="true"> Flight </th>
                                         <th>Departure</th>
                                        <th>Route</th>
                                        <th data-hide="all">Arrival</th>
                                        <th data-hide="all">Duration</th>
                                        <th data-hide="all"> Flight Status </th>
                                         <th data-hide="all"> Ticket Status </th>
                                                   <th data-hide="all"> Action </th>
                                    </tr>
                                </thead>
                                <tbody>
                                      <% Response.Write(data);%>
                                    
                       
                               
                                </tbody>
                                 <tfoot>
                                    <tr>
                                        <td colspan="5">
                                            <div class="text-right">
                                                <ul class="pagination pagination-split m-t-30"> </ul>
                                            </div>
                                        </td>
                                    </tr>
                                </tfoot>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
            
    <script src="plugins/bower_components/bootstrap-select/bootstrap-select.min.js"></script>
    <script src="plugins/bower_components/footable/js/footable.all.min.js"></script>
     <script src="plugins/bower_components/clockpicker/dist/jquery-clockpicker.min.js"></script>
    <script src="plugins/bower_components/bootstrap-datepicker/bootstrap-datepicker.min.js"></script>

    <script>
        // jQuery('.mydatepicker, #datepicker').datepicker();
       /* jQuery(function () {
            jQuery(".mydatepicker, #datepicker").datepicker();
            jQuery(".mydatepicker, #datepicker").on("change", function () {
                jQuery(".mydatepicker, #datepicker").datepicker("option", "dateFormat", 'yy-mm-dd');
            });
        });*/
        var dateToday = new Date();

        jQuery('.mydatepicker, #datepicker').datepicker({
            dateFormat: 'yy-mm-dd',
            autoclose: true,
            todayHighlight: true,
            format: 'yyyy-mm-dd',

            
           // appendText: "(yyyy-mm-dd)"
        });
   
      //  jQuery("#test").datepicker("option", "dateFormat", 'yy-mm-dd');
        function get()
        {
            jQuery(".mydatepicker, #datepicker").datepicker("option", "dateFormat", 'yy-mm-dd');
            alert(document.getElementById('test').value);
        }
    /*    jQuery('#date-range').datepicker({
            toggleActive: true
        });
        jQuery('#datepicker-inline').datepicker({
            todayHighlight: true
        });*/
      

        jQuery('#demo-foo-row-toggler').footable();
        jQuery('#demo-show-entries').change(function (e) {
            e.preventDefault();
            var pageSize = jQuery(this).val();
            jQuery('#demo-foo-pagination').data('page-size', pageSize);
            jQuery('#demo-foo-pagination').trigger('footable_initialized');
        });
    </script>
</asp:Content>

