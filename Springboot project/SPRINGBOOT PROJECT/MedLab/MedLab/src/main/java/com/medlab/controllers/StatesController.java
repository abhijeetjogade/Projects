package com.medlab.controllers;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import com.medlab.models.State;
import com.medlab.repository.StateRepository;

@RestController
@RequestMapping("/api/states")
public class StatesController {

    @Autowired
    private StateRepository stateRepository;

    // GET: api/states
    @GetMapping
    public ResponseEntity<List<State>> getAllStates() {
        List<State> states = stateRepository.findAll();
        return new ResponseEntity<>(states, HttpStatus.OK);
    }

    // GET: api/states/{id}
    @GetMapping("/{id}")
    public ResponseEntity<State> getStateById(@PathVariable int id) {
        return stateRepository.findById(id)
                .map(state -> new ResponseEntity<>(state, HttpStatus.OK))
                .orElseGet(() -> new ResponseEntity<>(HttpStatus.NOT_FOUND));
    }

    // POST: api/states
    @PostMapping
    public ResponseEntity<State> createState(@RequestBody State state) {
        try {
            State savedState = stateRepository.save(state);
            return new ResponseEntity<>(savedState, HttpStatus.CREATED);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }

    // PUT: api/states/{id}
    @PutMapping("/{id}")
    public ResponseEntity<State> updateState(@PathVariable int id, @RequestBody State stateDetails) {
        return stateRepository.findById(id)
                .map(state -> {
                    updateStateDetails(state, stateDetails);
                    State updatedState = stateRepository.save(state);
                    return new ResponseEntity<>(updatedState, HttpStatus.OK);
                })
                .orElseGet(() -> new ResponseEntity<>(HttpStatus.NOT_FOUND));
    }

    // DELETE: api/states/{id}
    @DeleteMapping("/{id}")
    public ResponseEntity<Void> deleteState(@PathVariable int id) {
        return stateRepository.findById(id)
                .map(state -> {
                    stateRepository.delete(state);
                    return new ResponseEntity<Void>(HttpStatus.NO_CONTENT);
                })
                .orElseGet(() -> new ResponseEntity<>(HttpStatus.NOT_FOUND));
    }

    // Helper method to update state details
    private void updateStateDetails(State state, State stateDetails) {
        state.setStateName(stateDetails.getStateName());
       
    }
}
