<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>@ViewBag.Title</title>
    <link href="https://fonts.googleapis.com/css?family=Open+Sans" rel="stylesheet">
    @Scripts.Render("~/bundles/modernizr")
    <link href="~/Content/bootstrap.css" rel="stylesheet">
  <link href="~/Content/campus.css" rel="stylesheet">

</head>
<body>
    @RenderBody()

    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/jqueryval")
    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?v=3.exp&key=AIzaSyCJDk7zVSngulzSCEZnf8zJaL3GqKH3cDE&libraries=drawing,places"></script>
    @RenderSection("scripts", required:=False)
</body>
</html>
