package com.medlab.controllers;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.medlab.models.LabAssistant;
import com.medlab.repository.LabAssistantRepository;

@RestController
@RequestMapping("/api/labassistants")
public class LabAssistantsController {

    @Autowired
    private LabAssistantRepository labAssistantRepository;

    // GET: api/labassistants
    @GetMapping
    public List<LabAssistant> getAllLabAssistants() {
        return labAssistantRepository.findAll();
    }

    // GET: api/labassistants/{id}
    @GetMapping("/{id}")
    public ResponseEntity<LabAssistant> getLabAssistant(@PathVariable Integer id) {
        Optional<LabAssistant> labAssistant = labAssistantRepository.findById(id);
        return labAssistant.map(ResponseEntity::ok).orElseGet(() -> ResponseEntity.notFound().build());
    }

    // POST: api/labassistants
    @PostMapping
    public ResponseEntity<LabAssistant> createLabAssistant(@RequestBody LabAssistant labAssistant) {
        LabAssistant savedLabAssistant = labAssistantRepository.save(labAssistant);
        return ResponseEntity.status(HttpStatus.CREATED).body(savedLabAssistant);
    }

    // PUT: api/labassistants/{id}
    @PutMapping("/{id}")
    public ResponseEntity<LabAssistant> updateLabAssistant(@PathVariable Integer id, @RequestBody LabAssistant labAssistantDetails) {
        return labAssistantRepository.findById(id).map(labAssistant -> {
            labAssistant.setUserID(labAssistantDetails.getUserID());
            labAssistant.setDepartmentID(labAssistantDetails.getDepartmentID());
           
            LabAssistant updatedLabAssistant = labAssistantRepository.save(labAssistant);
            return ResponseEntity.ok(updatedLabAssistant);
        }).orElseGet(() -> ResponseEntity.notFound().build());
    }

    // DELETE: api/labassistants/{id}
    @DeleteMapping("/{id}")
    public ResponseEntity<Object> deleteLabAssistant(@PathVariable Integer id) {
        return labAssistantRepository.findById(id).map(labAssistant -> {
            labAssistantRepository.delete(labAssistant);
            return ResponseEntity.noContent().build();
        }).orElseGet(() -> ResponseEntity.notFound().build());
    }
}
