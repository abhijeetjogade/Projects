package com.medlab.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import com.medlab.models.State;

@Repository
public interface StateRepository extends JpaRepository<State, Integer> {
    
}
