/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Check;

import static Check.SendMail.username;
import java.io.IOException;
import java.io.PrintWriter;
import javax.mail.Session;
import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

/**
 *
 * @author Le Thanh Tu
 */
public class ControllerSend extends HttpServlet {
       Email em = new Email();
       SendMail sendM = new SendMail();
       
    /**
     * Processes requests for both HTTP <code>GET</code> and <code>POST</code>
     * methods.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    protected void processRequest(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        response.setContentType("text/html;charset=UTF-8");
        PrintWriter out = response.getWriter();
        String to = request.getParameter("to");
        String cc = request.getParameter("cc");
        String title = request.getParameter("title");
        String content = request.getParameter("content");
        if (to.equals("")) {
            request.setAttribute("mess", "TO isn't empty");
            request.getRequestDispatcher("formEmail.jsp").forward(request, response);
        } else if (!to.matches("^[a-z][a-z0-9_\\.]{5,32}@[a-z0-9]{2,}(\\.[a-z0-9]{2,4}){1,2}$")) {
            request.setAttribute("mess", "Invalid Email To");
            request.getRequestDispatcher("formEmail.jsp").forward(request, response);
        } 
//        else if (!cc.matches("^[a-z][a-z0-9_\\.]{5,32}@[a-z0-9]{2,}(\\.[a-z0-9]{2,4}){1,2}$") && !cc.isEmpty()) {
//            request.setAttribute("mess", "Invalid Email CC");
//            request.getRequestDispatcher("formEmail.jsp").forward(request, response);
//        } 
        else if (title.isEmpty()) {
            request.setAttribute("mess", "Title isn't empty");
            request.getRequestDispatcher("formEmail.jsp").forward(request, response);
        } else if (content.isEmpty()) {
            request.setAttribute("mess", "Content isn't empty");
            request.getRequestDispatcher("formEmail.jsp").forward(request, response);
        }else{
            Session sessionS = sendM.getSession();
            sendM.getMessage(sessionS, to ,cc ,title, content);
            request.setAttribute("check", "done");
            request.setAttribute("messages", "Sent");
            request.getRequestDispatcher("sendmail.jsp").forward(request, response);
        }
    }

    // <editor-fold defaultstate="collapsed" desc="HttpServlet methods. Click on the + sign on the left to edit the code.">
    /**
     * Handles the HTTP <code>GET</code> method.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        processRequest(request, response);
    }

    /**
     * Handles the HTTP <code>POST</code> method.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        processRequest(request, response);
    }

    /**
     * Returns a short description of the servlet.
     *
     * @return a String containing servlet description
     */
    @Override
    public String getServletInfo() {
        return "Short description";
    }// </editor-fold>

}
