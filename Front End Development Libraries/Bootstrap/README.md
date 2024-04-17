Bootstrap

Bootstrap will figure out how wide your screen is and respond by resizing your HTML elements - hence the name responsive design.
With responsive design, there is no need to design a mobile version of your website. It will look good on devices with screens of any width.
You can add Bootstrap to any app by adding the following code to the top of your HTML:
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous"/>

Fluid containers
<div class="container-fluid"></div>

Make Images Mobile Responsive
It would be great if this image could be exactly the width of our phone's screen.
Fortunately, with Bootstrap, all we need to do is add the img-responsive class to your image. Do this, and the image should perfectly fit the width of your page.
<img class="img-responsive" src="">

Center Text with Bootstrap
Now that we're using Bootstrap, we can center our heading element to make it look better. All we need to do is add the class text-center to our h2 element.
<h2 class="text-center"></h2>

Create a Bootstrap Button
Bootstrap has its own styles for button elements, which look much better than the plain HTML ones. Give it the btn and btn-default classes. Normally, your button elements with the btn and btn-default classes are only as wide as the text that they contain.
<button class="btn btn-default"></button>

Create a Block Element Bootstrap Button
By making them block elements with the additional class of btn-block, your button will stretch to fill your page's entire horizontal space and any elements following it will flow onto a "new line" below the block.
<button class="btn btn-block"></button>

Taste the Bootstrap Button Color Rainbow
The btn-primary class is the main color you'll use in your app. It is useful for highlighting actions you want your user to take.
<button class="btn btn-block btn-primary"></button>

Call out Optional Actions with btn-info
Bootstrap comes with several pre-defined colors for buttons. The btn-info class is used to call attention to optional actions that the user can take.
<button class="btn btn-block btn-info"></button>

Warn Your Users of a Dangerous Action with btn-danger
Bootstrap comes with several pre-defined colors for buttons. The btn-danger class is the button color you'll use to notify users that the button performs a destructive action, such as deleting a photo.
 <button class="btn btn-block btn-danger"></button>

Use the Bootstrap Grid to Put Elements Side By Side
Bootstrap uses a responsive 12-column grid system, which makes it easy to put elements into rows and specify each element's relative width. Most of Bootstrap's classes can be applied to a div element.
Bootstrap has different column width attributes that it uses depending on how wide the user's screen is. For example, phones have narrow screens, and laptops have wider screens.
Take for example Bootstrap's col-md-* class. Here, md means medium, and * is a number specifying how many columns wide the element should be. In this case, the column width of an element on a medium-sized screen, such as a laptop, is being specified.
In the Cat Photo App that we're building, we'll use col-xs-*, where xs means extra small (like an extra-small mobile phone screen), and * is the number of columns specifying how many columns wide the element should be.
<div class="row">
    <div class="col-xs-4">
      <button class="btn btn-block btn-primary">Like</button>
    </div>
    <div class="col-xs-4">
      <button class="btn btn-block btn-info">Info</button>
    </div>
    <div class="col-xs-4">
      <button class="btn btn-block btn-danger">Delete</button>
    </div>
</div>

Ditch Custom CSS for Bootstrap
Bootstrap's built-in styles.
<h2 class="text-primary text-center"></h2>

Use a span to Target Inline Elements   
You can use spans to create inline elements. By using the inline span element, you can put several elements on the same line, and even style different parts of the same line differently. Give the span the class text-danger to make the text red.
<p>Top 3 things cats <span class="text-danger">hate:</span></p>

Create a Custom Heading
Bootstrap uses a responsive grid system, which makes it easy to put elements into rows and specify each element's relative width. Most of Bootstrap's classes can be applied to a div element.
<div class="row">
    <div class="col-xs-8">
      <h2 class="text-primary text-center">CatPhotoApp</h2>
    </div>
    <div class="col-xs-4">
      <a href="#"><img class="img-responsive thick-green-border" src="https://cdn.freecodecamp.org/curriculum/cat-photo-app/relaxing-cat.jpg" alt="A cute orange cat lying on its back."></a>
    </div>
  </div>

Add Font Awesome Icons to our Buttons
Font Awesome is a convenient library of icons. These icons can be webfonts or vector graphics. These icons are treated just like fonts. You can specify their size using pixels, and they will assume the font size of their parent HTML elements.
You can include Font Awesome in any app by adding the following code to the top of your HTML:
<link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.1/css/all.css" integrity="sha384-50oBUHEmvpQ+1lW4y57PTFmhCaXp0ML5d60M1M7uH2+nqUivzIebhndOJK28anvf" crossorigin="anonymous">
The i element was originally used to make other elements italic, but is now commonly used for icons. You can add the Font Awesome classes to the i element to turn it into an icon, for example:
<i class="fas fa-info-circle"></i>
Note that the span element is also acceptable for use with icons.

Responsively Style Radio Buttons
You can use Bootstrap's col-xs-* classes on form elements, too! This way, our radio buttons will be evenly spread out across the page, regardless of how wide the screen resolution is.

form-control
All textual <input>, <textarea>, and <select> elements with the class .form-control have a width of 100%.

Create Bootstrap Wells
Bootstrap has a class called well that can create a visual sense of depth for your columns.

Create a Class to Target with jQuery Selectors
Not every class needs to have corresponding CSS. Sometimes we create classes just for the purpose of selecting these elements more easily using jQuery.
Give each of your button elements the class target.