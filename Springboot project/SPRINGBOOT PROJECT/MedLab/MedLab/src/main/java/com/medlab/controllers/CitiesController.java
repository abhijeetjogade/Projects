package com.medlab.controllers;

import com.medlab.models.City;
import com.medlab.models.State;
import com.medlab.repository.CityRepository;
import com.medlab.repository.StateRepository;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.Optional;

@RestController
@RequestMapping("/api/cities")
public class CitiesController {

    @Autowired
    private CityRepository cityRepository;
    @Autowired
    private StateRepository stateRepository;

    // GET: api/cities
    @GetMapping
    public List<City> getAllCities() {
        return cityRepository.findAll();
    }

    // GET: api/cities/{id}
    @GetMapping("/{id}")
    public ResponseEntity<City> getCityById(@PathVariable Integer id) {
        Optional<City> city = cityRepository.findById(id);
        return city.map(ResponseEntity::ok).orElseGet(() -> ResponseEntity.notFound().build());
    }

    // POST: api/cities
    @PostMapping
    public City createCity(@RequestBody City city) {
        return cityRepository.save(city);
    }

    // PUT: api/cities/{id}
    @PutMapping("/{id}")
    public ResponseEntity<City> updateCity(@PathVariable Integer id, @RequestBody City cityDetails) {
        Optional<City> optionalCity = cityRepository.findById(id);
        
        if (optionalCity.isPresent()) {
            City existingCity = optionalCity.get();

            existingCity.setCityName(cityDetails.getCityName());

            State state = stateRepository.findById(cityDetails.getState().getStateId()).orElse(null); // Adjust this line based on your setup
            if (state != null) {
                existingCity.setState(state); // Set the State entity
            } else {
                return ResponseEntity.badRequest().body(null); // Handle invalid State ID
            }

            

            cityRepository.save(existingCity);
            return ResponseEntity.ok(existingCity);
        } else {
            return ResponseEntity.notFound().build();
        }
    }

    // DELETE: api/cities/{id}
    @DeleteMapping("/{id}")
    public ResponseEntity<Object> deleteCity(@PathVariable Integer id) {
        return cityRepository.findById(id).map(city -> {
            cityRepository.delete(city);
            return ResponseEntity.noContent().build();
        }).orElseGet(() -> ResponseEntity.notFound().build());
    }

}
