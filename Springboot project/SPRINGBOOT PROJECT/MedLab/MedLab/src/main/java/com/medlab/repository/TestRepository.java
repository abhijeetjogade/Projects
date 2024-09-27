package com.medlab.repository;

import org.springframework.data.jpa.repository.JpaRepository;

import com.medlab.models.Test;

public interface TestRepository extends JpaRepository<Test, Integer> {

}
