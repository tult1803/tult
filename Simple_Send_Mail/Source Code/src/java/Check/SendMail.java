package Check;


import java.util.Properties;
import javax.mail.Message;
import javax.mail.MessagingException;
import javax.mail.PasswordAuthentication;
import javax.mail.Session;
import javax.mail.Transport;
import javax.mail.internet.InternetAddress;
import javax.mail.internet.MimeMessage;

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
/**
 *
 * @author Le Thanh Tu
 */
public class SendMail {
    
    public static String username;
    public static String password;
    public Session getSession(){
        Properties props = new Properties();

        props.put("mail.smtp.auth", "true");
        props.put("mail.smtp.starttls.enable", "true");
        props.put("mail.smtp.host", "smtp.gmail.com");
        props.put("mail.smtp.port", "587");
        Session session = Session.getInstance(props,
                new javax.mail.Authenticator() {

            protected PasswordAuthentication getPasswordAuthentication() {

                return new PasswordAuthentication(username, password);

            }
        });
        return session;
    }
    
    public void getMessage(Session session, String userTO,String userCC, String title, String content){
        try {
            
            Message message = new MimeMessage(session);

            message.setFrom(new InternetAddress(username));

            message.setRecipients(Message.RecipientType.TO,
                    InternetAddress.parse(userTO));
            if(!userCC.isEmpty()){
                message.setRecipients(Message.RecipientType.CC,
                    InternetAddress.parse(userCC));
            }
            message.setSubject(title);
            
            message.setContent(content, "text/html; charset=utf-8");
//            message.setText("Hế lô");
            
            Transport.send(message);
        } catch (MessagingException e) {
            throw new RuntimeException(e);
        }
    
    } 
}
