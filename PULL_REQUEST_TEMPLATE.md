# How to contribute

When contributing to this repository, please first discuss the change you wish to make via issue, email, or any other method with us before making a change.

Please note we have a [Code of Conduct](https://github.com/Buzzcube/DojoManager/blob/master/CODE_OF_CONDUCT.md), please follow it in all your interactions with the project.

## Components

The application is written in Python 3.6 with Django as the framework with some Bootstrap 4. There are plans to add on an API and a mobile app, but that will be a seperate project.

## Getting Started

* Make sure you have a [Zenhub account](https://app.zenhub.com/login)
* Make sure you have a [GitHub account](https://github.com/signup/free)
* Submit a ticket for your issue, assuming one does not already exist.
  * Clearly describe the issue including steps to reproduce when it is a bug.
  * Make sure you fill in the earliest version that you know has the issue.

## Making Changes

* Create a topic branch from where you want to base your work.
  * This is usually the master branch.
  * Only target release branches if you are certain your fix must be on that
    branch.
  * To quickly create a topic branch based on master; `git checkout -b
    fix/master/my_contribution master`. Please avoid working directly on the
    `master` or the `develop` branch.
* Make commits of logical units.
* Check for unnecessary whitespace with `git diff --check` before committing.
* Make sure your commit messages are in the proper format.

````
    (#1234) Make the example in CONTRIBUTING imperative and concrete

    Without this patch applied the example commit message in the CONTRIBUTING
    document is not a concrete example.  This is a problem because the
    contributor is left to imagine what the commit message should look like
    based on a description rather than an example.  This patch fixes the
    problem by making the example concrete and imperative.

    The first line is a real life imperative statement with a ticket number
    from our issue tracker.  The body describes the behavior without the patch,
    why this is a problem, and how the patch fixes the problem when applied.
````

* Make sure you have added the necessary tests for your changes.
* Run _all_ the tests to assure nothing else was accidentally broken.
* Follow our [Code Review Process](https://github.com/Buzzcube/DojoManager/blob/master/CODEREVIEW.md)

## Making Trivial Changes

### Documentation

For changes of a trivial nature to comments and documentation, it is not always necessary to create a new ticket in [ZenHub](https://github.com/Buzzcube/DojoManager#boards?repos=91454773). In this case, it is
appropriate to start the first line of a commit with '(doc)' instead of a ticket number.

````
    (doc) Add documentation commit example to CONTRIBUTING

    There is no example for contributing a documentation commit
    to the repository. This is a problem because the contributor
    is left to assume how a commit of this nature may appear.

    The first line is a real life imperative statement with '(doc)' in
    place of what would have been the ticket number in a
    non-documentation related commit. The body describes the nature of
    the new documentation or comments added.
````

## Applying the GPL license to the source

Attach the following notices to the code. It is safest to attach them
to the start of each source file to most effectively state the exclusion of warranty;
and each file should have at least the &ldquo;copyright&rdquo; line and a pointer to
where the full notice is found.

````
    DojoManager
    -----------
    A complete management tool for Dojos.
    Copyright (C) 2017 Richard Soderblom

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
````
## Submitting Changes

* Push your changes to a topic branch in your fork of the repository.
* Submit a pull request to the repository in the Buzzcube organization.
* Update your [ZenHub](https://github.com/Buzzcube/DojoManager#boards?repos=91454773) ticket to mark that you have submitted code and are ready for it to be reviewed (Status: Ready for Merge).
* Include a link to the pull request in the ticket.
* The team looks at Pull Requests on a regular basis.
* After feedback has been given we expect responses within two weeks. After two weeks we may close the pull request if it isn't showing any activity.
* Once you have received feedback and the change has been signed-off by at least one reviewer, you may merge the change. If you do not have permission to merge then you may request the last reviewer to do the merge for you.

## Revert Policy
By running tests in advance and by engaging with peer review for prospective changes, your contributions have a high probability of becoming long lived parts of the the project. After being merged, the code will run through a series of testing pipelines on a large number of operating system environments. These pipelines can reveal incompatibilities that are difficult to detect in advance.

If the code change results in a test failure, we will make our best effort to correct the error. If a fix cannot be determined and committed within 24 hours of its discovery, the commit(s) responsible _may_ be reverted, at the discretion of the committer and maintainers. This action would be taken to help maintain passing states in our testing pipelines.

The original contributor will be notified of the revert in the [ZenHub](https://github.com/Buzzcube/DojoManager#boards?repos=91454773) ticket associated with the change. A reference to the test(s) and operating system(s) that failed as a result of the code change will also be added to the [ZenHub](https://github.com/Buzzcube/DojoManager#boards?repos=91454773) ticket. This test(s) should be used to check future submissions of the code to ensure the issue has been resolved.

### Summary
* Changes resulting in test pipeline failures will be reverted if they cannot be resolved within one business day.

# Additional Resources
* [DojoManager mailing list](https://groups.google.com/forum/#!forum/dojomanager)
* [ZenHub project board](https://github.com/Buzzcube/DojoManager#boards?repos=91454773)
* [Code of Conduct](https://github.com/Buzzcube/DojoManager/blob/master/CODE_OF_CONDUCT.md)
* [Code Review Process](https://github.com/Buzzcube/DojoManager/blob/master/CODEREVIEW.md)
* [High level view Mind Map](https://coggle.it/diagram/WcO4AEU4KwABxMp-/b8de91dd7d1c2abce9afdd02d39e64fc5c4dea47fa08450153d7e863fa4c31d0)
