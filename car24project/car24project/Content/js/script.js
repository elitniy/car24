//slider section

$('.carousel').carousel({
  interval: 20
});
}).each(function(i) {
  if(this.complete) {
  	var item = $('<div class="item"></div>');
    var itemDiv = $(this).parents('div');
    var title = $(this).parent('a').attr("title");
    
    item.attr("title",title);
  	$(itemDiv.html()).appendTo(item);
  	item.appendTo('.carousel-inner'); 
    if (i==0){ // set first item active
     item.addClass('active');
    }
  }
});

//END SLIDER SECTION


//CAR LOGO PARALLAX SECTION
$(window).ready(function(){
 i=0
 function setInter(){
 $(".interval p").html(i);
  if (i === 157) {
        }
        else {
            i++;
        }
 }
 setInterval(setInter,1.2)
})
$(window).ready(function(){
 a=0
 function setIntersecond(){
 $(".secondinterval p").html(a);
  if (a === 250) {

        }
        else {
            a++;
        }
 }
 setInterval(setIntersecond,0.1)
})
$(window).ready(function(){
 b=0
 function setInterthird(){

 $(".thirdinterval p").html(b);
  if (b === 24100) {
        }
        else {
            b+=100;
        }
 }
 setInterval(setInterthird,0.2)
})
// END CAR LOGO PARALLAX SECTION
