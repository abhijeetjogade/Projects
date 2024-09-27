package com.medlab.controllers;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.medlab.models.Patient;
import com.medlab.repository.PatientRepository;

@RestController
@RequestMapping("/api/patients")
public class PatientsController {

    @Autowired
    private PatientRepository patientRepository;

    // GET: api/patients
    @GetMapping
    public List<Patient> getAllPatients() {
        return patientRepository.findAll();
    }

    // GET: api/patients/{id}
    @GetMapping("/{id}")
    public ResponseEntity<Patient> getPatientById(@PathVariable int id) {
        Optional<Patient> patient = patientRepository.findById(id);
        if (patient.isPresent()) {
            return ResponseEntity.ok(patient.get());
        } else {
            return ResponseEntity.notFound().build();
        }
    }

    // POST: api/patients
    @PostMapping
    public Patient createPatient(@RequestBody Patient patient) {
        return patientRepository.save(patient);
    }

    // PUT: api/patients/{id}
    @PutMapping("/{id}")
    public ResponseEntity<Patient> updatePatient(@PathVariable int id, @RequestBody Patient patientDetails) {
        Optional<Patient> patient = patientRepository.findById(id);

        if (patient.isPresent()) {
            Patient updatedPatient = patient.get();
            updatedPatient.setName(patientDetails.getName());
            updatedPatient.setEmail(patientDetails.getEmail());
            updatedPatient.setPhone(patientDetails.getPhone());
            updatedPatient.setAge(patientDetails.getAge());
            updatedPatient.setAddress(patientDetails.getAddress());
            updatedPatient.setState(patientDetails.getState());
            
            patientRepository.save(updatedPatient);
            return ResponseEntity.ok(updatedPatient);
        } else {
            return ResponseEntity.notFound().build();
        }
    }

    // DELETE: api/patients/{id}
    @DeleteMapping("/{id}")
    public ResponseEntity<Void> deletePatient(@PathVariable int id) {
        Optional<Patient> patient = patientRepository.findById(id);

        if (patient.isPresent()) {
            patientRepository.delete(patient.get());
            return ResponseEntity.noContent().build();
        } else {
            return ResponseEntity.notFound().build();
        }
    }
}
