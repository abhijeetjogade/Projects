package com.medlab.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.medlab.models.LabAssistant;

@Repository
public interface LabAssistantRepository extends JpaRepository<LabAssistant, Integer> {
}