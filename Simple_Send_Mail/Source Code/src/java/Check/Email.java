/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Check;

/**
 *
 * @author Le Thanh Tu
 */
public class Email {
    private String usernameTo, usernameCC, title, content;

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public String getContent() {
        return content;
    }

    public void setContent(String content) {
        this.content = content;
    }

    public String getUsernameCC() {
        return usernameCC;
    }

    public void setUsernameCC(String usernameCC) {
        this.usernameCC = usernameCC;
    }

    public String getUsernameTo() {
        return usernameTo;
    }

    public void setUsernameTo(String usernameTo) {
        this.usernameTo = usernameTo;
    }

    public Email(String usernameTo, String usernameCC, String title, String content) {
        this.usernameTo = usernameTo;
        this.usernameCC = usernameCC;
        this.title = title;
        this.content = content;
    }

    
    public Email() {
    }
    
}
