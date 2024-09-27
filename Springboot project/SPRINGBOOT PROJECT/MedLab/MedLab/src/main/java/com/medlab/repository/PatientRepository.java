package com.medlab.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.medlab.models.Patient;

@Repository
public interface PatientRepository extends JpaRepository<Patient, Integer> {
}
