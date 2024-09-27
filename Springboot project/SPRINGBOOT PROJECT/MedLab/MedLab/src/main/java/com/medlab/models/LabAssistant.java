package com.medlab.models;

import java.time.LocalDateTime;

import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.JoinColumn;
import jakarta.persistence.ManyToOne;
import jakarta.persistence.Table;

@Entity
@Table(name = "lab_assistants")
public class LabAssistant {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer labAssistantID;

    @Column(nullable = false)
    private String userID;

    @ManyToOne
    @JoinColumn(name = "user_id", referencedColumnName = "id")
    private User user;

    @Column(nullable = false)
    private Integer departmentID;

    @ManyToOne
    @JoinColumn(name = "department_id", referencedColumnName = "departmentID")
    private Department department;

   

    // Getters and Setters
    public Integer getLabAssistantID() {
        return labAssistantID;
    }

    public void setLabAssistantID(Integer labAssistantID) {
        this.labAssistantID = labAssistantID;
    }

    public String getUserID() {
        return userID;
    }

    public void setUserID(String userID) {
        this.userID = userID;
    }

    public User getUser() {
        return user;
    }

    public void setUser(User user) {
        this.user = user;
    }

    public Integer getDepartmentID() {
        return departmentID;
    }

    public void setDepartmentID(Integer departmentID) {
        this.departmentID = departmentID;
    }

    public Department getDepartment() {
        return department;
    }

    public void setDepartment(Department department) {
        this.department = department;
    }

   
}