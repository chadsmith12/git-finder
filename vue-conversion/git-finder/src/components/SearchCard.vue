<template>
    <div class="search card card-body">
        <h1>Search GitHub Users</h1>
        <p class="lead">Enter username to fetch user profile and repositories</p>
        <div class="form-group row">
            <div class="col-md-12">
                <input type="text" id="userSearch" class="form-control" placeholder="GitHub Username..."/>
            </div>
        </div>
        <div class="form-group row">
            <label class="col-md-2 col-form-label">Number of Repos</label>
            <div class="col-md-5">
                <select class="form-control">
                    <option value="5">5</option>
                    <option value="10">10</option>
                    <option value="15">15</option>
                </select>
            </div>
            <label class="col-md-1 col-form-label">Sort By</label>
            <div class="col-md-4">
                <select class="form-control">
                    <option value="asc">Created At - Ascending</option>
                    <option value="desc">Created At - Descending</option>
                </select>
            </div>
        </div>
        <div class="row">
            <div class="col-md-6">
                <button type="button" class="btn btn-primary">Search</button>
            </div>
        </div>
    </div>    
</template>

<script>
export default {
    
}
</script>



