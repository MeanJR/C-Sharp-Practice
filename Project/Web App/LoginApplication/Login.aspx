<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LoginApplication.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title></title>

    <!-- Required meta tags -->
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1"/>

    <!-- Bootstrap CSS -->    
    <link href="css/bootstrap.min.css" rel="stylesheet" />

   <style>
        input[type ="text"],input[type="password"]{
            display: block;
            padding: 10px;
            margin-bottom:24px;
            width:100%;

        }

        input[type ="submit"]:hover{
                border:2px solid #0093E0;
                outline:none;
                background-color: #0093E0;
            }

        .user-img {
	        margin-top: -100px;
	        margin-bottom: 30px;            
            }
        .user-img img {
	            height: 120px;
	            width: 120px;
            }
        .forgot {
	        padding: 50px 25px 25px 40%;
        }
        .forgot a {
         color: #daf1ff;
            }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div>
        <div style="background-image: url('img/Books2.jpg'); " class ="vh-100">
            <!--
            <header class="p-3 bg-dark text-white">
            <div class="container" style="background-image: inherit">
              <div class="d-flex flex-wrap align-items-center justify-content-center justify-content-lg-start">
                <a href="/" class="d-flex align-items-center mb-2 mb-lg-0 text-white text-decoration-none">
                  <svg class="bi me-2" width="40" height="32" role="img" aria-label="Bootstrap"><use xlink:href="#bootstrap"></use></svg>
                </a>

                <ul class="nav col-12 col-lg-auto me-lg-auto mb-2 justify-content-center mb-md-0">
                  <li><a href="#" class="nav-link px-2 text-secondary">Home</a></li>
                  <li><a href="#" class="nav-link px-2 text-white">Features</a></li>
                  <li><a href="#" class="nav-link px-2 text-white">Pricing</a></li>
                  <li><a href="#" class="nav-link px-2 text-white">FAQs</a></li>
                  <li><a href="#" class="nav-link px-2 text-white">About</a></li>
                </ul>

                <div class="text-end">
 
                      <asp:Button ID="sign" runat="server" Text="Sign-up" class="btn btn-warning"/>
                </div>
              </div>
            </div>
          </header>

                -->
          
         <div style ="padding-top: 10%">
                <div style ="width: 600px; height:450px; border-radius: 24px; padding:45px 26px 77px 26px;" class="mx-auto align-self-center bg-dark">
                    <div class="col-12 user-img">
                      <img src="img/face.png" />
                    </div>

                    <h1 style = "color:azure; font-size: 30px; margin-bottom:32px; opacity:1.0">Login</h1>
                    <formview>
                        <input id="txtUser" type="text" runat="server" placeholder ="Username" />
                        <input id="PasswordLogin" type ="password" placeholder ="Password" runat="server"/>
                        <asp:Button ID="LoginClick" runat="server" Text="Login" class="btn btn-outline-light" OnClick="login_Click"/>        
                        <asp:Button ID="Signup" runat="server" Text="Sign-up" class="btn btn-warning" />
                        
                    </formview>
                  <div class="col-12 forgot">
                        <a href="#">Forgot Password?</a>
                      <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

                  </div>
                </div>
            </div>

      </div>
        </div>
    </form>
</body>
</html>
