package com.example.serviceenineer;

public class Users {
    private String id;
    private String email;
    private String full_name;
    private String password;

    public Users(String id, String email, String full_name, String password) {
        this.id = id;
        this.email = email;
        this.full_name = full_name;
        this.password = password;
    }

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public String getFull_name() {
        return full_name;
    }

    public void setFull_name(String full_name) {
        this.full_name = full_name;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }
}
