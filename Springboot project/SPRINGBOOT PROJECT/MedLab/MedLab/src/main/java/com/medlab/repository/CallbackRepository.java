package com.medlab.repository;

import org.springframework.data.jpa.repository.JpaRepository;

import com.medlab.models.Callback;

public interface CallbackRepository extends JpaRepository<Callback, Integer> {

}
