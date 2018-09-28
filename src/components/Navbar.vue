<template>
    <nav class="navbar navbar-dark bg-primary mb-3">
        <div class="container">
            <a href="#" class="navbar-brand">{{ title }}</a>
        </div>
    </nav>
</template>

<script>
export default {
    props: {
        title: String
    }
}
</script>

