package com.medlab.repository;

import org.springframework.data.jpa.repository.JpaRepository;

import com.medlab.models.Appointment;


public interface AppointmentReository extends JpaRepository<Appointment, Integer> {

}
