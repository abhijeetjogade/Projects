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

import com.medlab.models.Callback;
import com.medlab.repository.CallbackRepository;

@RestController
@RequestMapping("/api/callbacks")
public class CallbacksController {

    @Autowired
    private CallbackRepository callbackRepository;

    // GET: api/callbacks
    @GetMapping
    public List<Callback> getCallbacks() {
        return callbackRepository.findAll();
    }

    // GET: api/callbacks/{id}
    @GetMapping("/{id}")
    public ResponseEntity<Callback> getCallback(@PathVariable int id) {
        Optional<Callback> callback = callbackRepository.findById(id);
        return callback.map(ResponseEntity::ok).orElseGet(() -> ResponseEntity.notFound().build());
    }

    // POST: api/callbacks
    @PostMapping
    public ResponseEntity<Callback> postCallback(@RequestBody Callback callback) {
        Callback savedCallback = callbackRepository.save(callback);
        return ResponseEntity.ok(savedCallback);
    }

    // PUT: api/callbacks/{id}
    @PutMapping("/{id}")
    public ResponseEntity<Callback> putCallback(@PathVariable int id, @RequestBody Callback callback) {
        if (!callbackRepository.existsById(id)) {
            return ResponseEntity.notFound().build();
        }
        callback.setId(id);
        Callback updatedCallback = callbackRepository.save(callback);
        return ResponseEntity.ok(updatedCallback);
    }

    // DELETE: api/callbacks/{id}
    @DeleteMapping("/{id}")
    public ResponseEntity<Void> deleteCallback(@PathVariable int id) {
        if (!callbackRepository.existsById(id)) {
            return ResponseEntity.notFound().build();
        }
        callbackRepository.deleteById(id);
        return ResponseEntity.noContent().build();
    }
}