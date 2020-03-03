package Check;

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author Admin
 */
public class info {
    private String title, content_summary,time, article_content, author;
    private String message = "";

    public info() {
    }

    public info(String title, String content_summary, String time, String article_content, String author, String message) {
        this.title = title;
        this.content_summary = content_summary;
        this.time = time;
        this.article_content = article_content;
        this.author = author;
        this.message = message;
    }

    public String getMessage() {
        return message;
    }

    public void setMessage(String message) {
        this.message = message;
    }

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public String getContent_summary() {
        return content_summary;
    }

    public void setContent_summary(String content_summary) {
        this.content_summary = content_summary;
    }

    public String getTime() {
        return time;
    }

    public void setTime(String time) {
        this.time = time;
    }

    public String getArticle_content() {
        return article_content;
    }

    public void setArticle_content(String article_content) {
        this.article_content = article_content;
    }

    public String getAuthor() {
        return author;
    }

    public void setAuthor(String author) {
        this.author = author;
    }
}
