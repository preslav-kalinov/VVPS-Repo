package com.dzone.albanoj2.refactoring.hockey;

import org.junit.Before;
import org.junit.Test;

import static org.junit.Assert.assertNotNull;

public class GameTest {
    private Game game;

    @Before
    public void setUp() {
        game = new Game(6, 28, 68);
    }

    @Test
    public void getGoalsAgainstEnsureNotNull() {
        assertNotNull(game.getGoalsAgainst());
    }

    @Test
    public void getShotsOnGoalAgainstEnsureNotNull() {
        assertNotNull(game.getShotsOnGoalAgainst());
    }

    @Test
    public void getMinutesPlayedEnsureNotNull() {
        assertNotNull(game.getMinutesPlayed());
    }

}
