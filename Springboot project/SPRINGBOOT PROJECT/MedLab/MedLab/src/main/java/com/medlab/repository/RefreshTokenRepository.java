package com.medlab.repository;

import java.util.Optional;

import org.springframework.data.jpa.repository.JpaRepository;

import com.medlab.models.RefreshToken;

public interface RefreshTokenRepository extends JpaRepository<RefreshToken, Long> {
    Optional<RefreshToken> findByToken(String token);

}
