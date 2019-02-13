$(function () {

  'use strict';
  $('#scroll-content').slimscroll({
      width: '100%',
      height: '400px'
});
  // Make the dashboard widgets sortable Using jquery UI
  $('.connectedSortable').sortable({
    placeholder         : 'sort-highlight',
    connectWith         : '.connectedSortable',
    handle              : '.box-header, .nav-tabs',
    forcePlaceholderSize: true,
    zIndex              : 999999
  });
  $('.connectedSortable .box-header, .connectedSortable .nav-tabs-custom').css('cursor', 'move');

  // jQuery UI sortable for the todo list
  $('.todo-list').sortable({
    placeholder         : 'sort-highlight',
    handle              : '.handle',
    forcePlaceholderSize: true,
    zIndex              : 999999
  });


  

  /* The todo list plugin */
  $('.todo-list').todoList({
      onCheck: function () {
          
          
          
          $(this).parent().addClass("complete");
          $.ajax({
              url: '/Home/IsComplete',
              type: "POST",
              data: {
                  chk: true ,
                  id: $(this).attr('id')
              }
          }).done(function () {
             
          });    
        //  window.console.log($(this), 'The element has been checked now' + $(this).attr('id') + " " + $(this).parent().attr('id'));
        //window.console.log();


    },
      onUnCheck: function () {
          

          $(this).parent().removeClass("complete");

          $.ajax({
              url: '/Home/IsComplete',
              type: "POST",
              data: {
                  chk: false,
                  id: $(this).attr('id')
              }
          }).done(function () {
             
          });
         
    }
  });


    

});

//$("#des").change(function () {
//    var text = $(this).val();
//    if (text === null || text ===" ") {
//        $('#create').attr('disabled', 'disabled');
//    } else {
        
//        $('#create').removeAttr('disabled');
//    }
//});

$(document).ready(function () {
    $("#des").val('');
});
//$(function() {


//    //iCheck for checkbox and radio inputs
//    $('input[type="checkbox"].minimal, input[type="radio"].minimal').iCheck({
//        checkboxClass: 'icheckbox_minimal-blue',
//        radioClass: 'iradio_minimal-blue'
//    })
//    //Red color scheme for iCheck
//    $('input[type="checkbox"].minimal-red, input[type="radio"].minimal-red').iCheck({
//        checkboxClass: 'icheckbox_minimal-red',
//        radioClass: 'iradio_minimal-red'
//    })
//    //Flat red color scheme for iCheck
//    $('input[type="checkbox"].flat-red, input[type="radio"].flat-red').iCheck({
//        checkboxClass: 'icheckbox_flat-green',
//        radioClass: 'iradio_flat-green'
//    })
//})