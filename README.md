<h2>Requirements</h2>
<ul>
  <li>.NET 7.0 </li>
  <li>SQL Server</li>
</ul>

<h2>Installation</h2>
<ol>
  <li>Clone project.</li>
  <li>Create "StyleShop" database in SQL Server.</li>
  <li>Set up server name in connection string which is place in <code>StyleShop.MVC</code> project in file <code>appsettings.json</code></li>
  <li>Run <code>update-database</code> command to apply migrations in database. </br>
    ⚠️ If you are using <code>Package Manage Console</code> don't forget to set up Default project as <code>StyleShop.Infrastructure</code></li>
  <li>Before run application make sure in solution explorer you have <code>StyleShop.MVC</code> project set up as Startup Project</li>
</ol>
<h2>Features</h2>
<ul>
  <li> 
    💂 Logged user with <code>ADMIN</code> role can do:
    <ul>
      <li>
        <code>Product</code>
        <ul>
          <li>Create</li>
          <li>Read all/specific</li>
          <li>Update</li>
          <li>Delete</li>
        </ul>
      </li>
      <li>
        <code>Order</code>
        <ul>
          <li>Create</li>
          <li>Read all/specific</li>
          <li>Update only order status</li>
          <li>Delete</li>
        </ul>
      </li>
    </ul>
  </li>
  <li>
    👨‍💼 Logged user can do:
    <ul>
      <li>
        <code>Product</code>
        <ul>
          <li>Read all/specific</li>
        </ul>
      </li>
      <li>
        <code>Order</code>
        <ul>
          <li>Create</li>
          <li>Read all/specific created by user</li>
        </ul>
      </li>
    </ul>
  </li>
  <li>
    🕵️ Anonymous user
    <ul>
      <li>
        <code>Product</code>
        <ul>
          <li>Read all/specific</li>
        </ul>
      </li>
      <li>
        <code>Order</code>
        <ul>
          <li>Nothing</li>
        </ul>
      </li>
    </ul>
  </li>
</ul>
