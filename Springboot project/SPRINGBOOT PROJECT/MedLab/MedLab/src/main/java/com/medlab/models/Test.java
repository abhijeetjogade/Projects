package com.medlab.models;

import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.JoinColumn;
import jakarta.persistence.ManyToOne;
import jakarta.validation.constraints.DecimalMin;
import jakarta.validation.constraints.NotNull;
import jakarta.validation.constraints.Size;

@Entity
	public class Test {

	    @Id
	    @GeneratedValue(strategy = GenerationType.IDENTITY)
	    private int testID;

	    @NotNull
	    @Size(max = 100)
	    private String testName;

	    @NotNull(message = "Price is required")
	    @DecimalMin("0.0")
	    private double price;

	    @NotNull(message = "Department Id is required")
	    private int departmentID;

	    @ManyToOne
	    @JoinColumn(name = "departmentID", insertable = false, updatable = false)
	    private Department department;

		public int getTestID() {
			return testID;
		}

		public void setTestID(int testID) {
			this.testID = testID;
		}

		public String getTestName() {
			return testName;
		}

		public void setTestName(String testName) {
			this.testName = testName;
		}

		public double getPrice() {
			return price;
		}

		public void setPrice(double price) {
			this.price = price;
		}

		public int getDepartmentID() {
			return departmentID;
		}

		public void setDepartmentID(int departmentID) {
			this.departmentID = departmentID;
		}

		public Department getDepartment() {
			return department;
		}

		public void setDepartment(Department department) {
			this.department = department;
		}
	    
	    
}
