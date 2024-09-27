package com.medlab.repository;

import java.util.Optional;

import org.springframework.data.jpa.repository.JpaRepository;

import com.medlab.models.User;

public interface UserRepository extends JpaRepository<User, Long> {
    Optional<User> findByEmail(String email); 

}
