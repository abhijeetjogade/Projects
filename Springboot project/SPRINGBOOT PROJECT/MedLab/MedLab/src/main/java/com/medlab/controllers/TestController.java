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

import com.medlab.models.Test;
import com.medlab.repository.TestRepository;

import jakarta.validation.Valid;

@RestController
@RequestMapping("/api/tests")
public class TestController {

    @Autowired
    private TestRepository testRepository;

    // GET: api/tests
    @GetMapping
    public List<Test> getAllTests() {
        return testRepository.findAll();
    }

    // GET: api/tests/{id}
    @GetMapping("/{id}")
    public ResponseEntity<Test> getTestById(@PathVariable int id) {
        Optional<Test> test = testRepository.findById(id);
        return test.map(ResponseEntity::ok).orElseGet(() -> ResponseEntity.notFound().build());
    }

    // POST: api/tests
    @PostMapping
    public ResponseEntity<Test> createTest(@Valid @RequestBody Test test) {
        Test savedTest = testRepository.save(test);
        return ResponseEntity.ok(savedTest);
    }

    // PUT: api/tests/{id}
    @PutMapping("/{id}")
    public ResponseEntity<Test> updateTest(@PathVariable int id, @Valid @RequestBody Test testDetails) {
        Optional<Test> optionalTest = testRepository.findById(id);
        if (!optionalTest.isPresent()) {
            return ResponseEntity.notFound().build();
        }
        Test test = optionalTest.get();
        test.setTestName(testDetails.getTestName());
        test.setPrice(testDetails.getPrice());
        test.setDepartmentID(testDetails.getDepartmentID());
        Test updatedTest = testRepository.save(test);
        return ResponseEntity.ok(updatedTest);
    }

    // DELETE: api/tests/{id}
    @DeleteMapping("/{id}")
    public  ResponseEntity<Object> deleteTest(@PathVariable int id) {
        Optional<Test> optionalTest = testRepository.findById(id);
        if (!optionalTest.isPresent()) {
            return ResponseEntity.notFound().build();
        }
        testRepository.delete(optionalTest.get());
        return ResponseEntity.noContent().build();
    }
}
