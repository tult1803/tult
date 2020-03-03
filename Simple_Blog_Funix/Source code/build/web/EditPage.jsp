<%-- 
    Document   : PostDetail
    Created on : Oct 23, 2019, 7:40:50 PM
    Author     : Admin
--%>

<%@page import="Check.Controller"%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<head>

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">

    <title>Clean Blog - Start Bootstrap Theme</title>

    <!-- Bootstrap core CSS -->
    <link href="vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet">

    <!-- Custom fonts for this template -->
    <link href="vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css">
    <link href='https://fonts.googleapis.com/css?family=Lora:400,700,400italic,700italic' rel='stylesheet' type='text/css'>
    <link href='https://fonts.googleapis.com/css?family=Open+Sans:300italic,400italic,600italic,700italic,800italic,400,300,600,700,800' rel='stylesheet' type='text/css'>

    <!-- Custom styles for this template -->
    <link href="css/clean-blog.min.css" rel="stylesheet">

</head>
<body>
    <%
        Controller control = new Controller();
        String timer = java.time.LocalDate.now() + "";
    %>
    <!-- Page Header -->
    <header class="masthead" style="background-image: url('img/home-bg.jpg')">
        <div class="overlay"></div>
        <div class="container">
            <div class="row">
                <div class="col-lg-8 col-md-10 mx-auto">
                    <div class="site-heading">
                        <h1>Edit Blog</h1>
                        <!--<span class="subheading">A Blog Theme by Start Bootstrap</span>-->
                    </div>
                </div>
            </div>
        </div>
    </header>

    <!-- Main Content -->
    <div class="container">
        <div class="row">
            <div class="col-lg-8 col-md-10 mx-auto">
                <form action="updateDB" method="post">
                <div class="post-preview">
                    <h2 class="post-title" style="color: red">Title</h2>
                    <textarea name="title"  style="width: 100%;height: 50px;"><% out.print(control.list.get(0));%></textarea>
                    <h3 class="post-subtitle">Sub Content</h3>
                    <textarea name="subcontent"  style="width: 100%;height: 200px;"><% out.print(control.list1.get(0));%></textarea>
                    <h3 class="post-subtitle"> Main Content </h3>
                        <textarea name="content"  style="width: 100%;height: 500px;"><% out.print(control.list2.get(0));%></textarea>
                    <h3 class="post-subtitle"> Author </h3>       
                    <textarea name="author"  style="width: 100%;height: 40px;"><% out.print(control.list4.get(0));%></textarea>
                    <span>Date: <% out.print(control.list3.get(0)); %> </span>
                    <input type="hidden" name="time" value="<%= timer %>" />
                    <input type="hidden" name="id" value="1" />
                    <center><input style="width: 100px;height: 50px;" type="submit" value="Save"/></center>
                </div>
                </form>
                <hr>
            </div>
        </div>
    </div>

    <hr>

    <!-- Footer -->
    <footer>
        <div class="container">
            <div class="row">
                <div class="col-lg-8 col-md-10 mx-auto">
                    <ul class="list-inline text-center">
                        <li class="list-inline-item">
                            <a href="#">
                                <span class="fa-stack fa-lg">
                                    <i class="fas fa-circle fa-stack-2x"></i>
                                    <i class="fab fa-twitter fa-stack-1x fa-inverse"></i>
                                </span>
                            </a>
                        </li>
                        <li class="list-inline-item">
                            <a href="#">
                                <span class="fa-stack fa-lg">
                                    <i class="fas fa-circle fa-stack-2x"></i>
                                    <i class="fab fa-facebook-f fa-stack-1x fa-inverse"></i>
                                </span>
                            </a>
                        </li>
                        <li class="list-inline-item">
                            <a href="#">
                                <span class="fa-stack fa-lg">
                                    <i class="fas fa-circle fa-stack-2x"></i>
                                    <i class="fab fa-github fa-stack-1x fa-inverse"></i>
                                </span>
                            </a>
                        </li>
                    </ul>
                    <p class="copyright text-muted">Copyright &copy; Your Website 2019</p>
                </div>
            </div>
        </div>
    </footer>

    <!-- Bootstrap core JavaScript -->
    <script src="vendor/jquery/jquery.min.js"></script>
    <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

    <!-- Custom scripts for this template -->
    <script src="js/clean-blog.min.js"></script>

</body>

</html>
