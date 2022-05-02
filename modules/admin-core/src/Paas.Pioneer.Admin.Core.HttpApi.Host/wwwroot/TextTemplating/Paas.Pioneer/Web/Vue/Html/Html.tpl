{{~
   func initial_lower
    ret ( $0 | string.slice1 0 | string.downcase ) + ($0 | string.slice 1 )
end ~}}
<template>
  <my-container v-loading="pageLoading">
    <!--顶部操作-->
    <template #header>
      <el-form class="ad-form-query" :inline="true" @submit.native.prevent>
        <el-form-item>
          <my-search :fields="fields" @click="onSearch" />
        </el-form-item>
        <el-form-item v-if="checkPermission(['api:admin:{{ model.taxon | string.downcase }}:add'])">
        <el-button type="primary" @click="onAdd">新增</el-button>
        </el-form-item>
        <el-form-item v-if="checkPermission(['api:admin:{{ model.taxon | string.downcase }}:delete'])">
        <my-confirm-button
          :disabled="sels.length === 0"
          :type="'delete'"
          :placement="'bottom-end'"
          :loading="deleteLoading"
          style="margin-left: 0px;"
          @click="onBatchDelete"
        >
          <template #content>
            <p>确定要批量删除吗？</p>
          </template>
          批量删除
        </my-confirm-button>
      </el-form-item>
      </el-form>
    </template>

    <!--列表-->
    <el-table
      v-loading="listLoading"
      :data="pageList"
      highlight-current-row
      height="'100%'"
      style="width: 100%;height:100%;"
      @selection-change="onSelsChange"
    >
      <el-table-column type="selection" width="50" />
{{~ for item in   model.low_code_table_config_list ~}}
      {{~ if item.is_web_show ~}}
      <el-table-column prop="{{ initial_lower item.column_name }}" label="{{ item.column_comment }}" {{ if item.net_type=="DateTime" }} :formatter="formatCreatedTime" {{ end }}/>
      {{~ end ~}}
{{~ end ~}}
      <el-table-column v-if="checkPermission(['api:admin:{{ model.taxon | string.downcase }}:update','api:admin:{{ model.taxon | string.downcase }}:delete'])" label="操作" width="180">
        <template #default="{ $index, row }">
          <el-button v-if="checkPermission(['api:admin:{{ model.taxon | string.downcase }}:update'])" @click="onEdit($index, row)">编辑</el-button>
          <my-confirm-button v-if="checkPermission(['api:admin:{{ model.taxon | string.downcase }}:delete'])" type="delete" :loading="row._loading" @click="onDelete($index, row)" />
        </template>
      </el-table-column>
    </el-table>

    <!--分页-->
    <template #footer>
      <my-pagination
        ref="pager"
        :total="total"
        :checked-count="sels.length"
        @get-page="pageList"
      />
    </template>

    <!-- 添加 -->
    <my-window
      v-if="checkPermission(['api:admin:{{ model.taxon | string.downcase }}:add'])"
      title="添加"
      :visible.sync="addDialogFormVisible"
      @close="closeAddForm"
    >
      <el-form
        ref="addForm"
        :model="addForm"
        :rules="addFormRules"
        label-width="80px"
        :inline="false"
      >
{{~ for item in   model.low_code_table_config_list ~}}
      {{~ if item.is_web_add ~}}
      {{~ if item.input_type == "Upload"  ~}}
      <el-form-item label="{{ item.column_comment }}" prop="{{ initial_lower item.column_name }}">
         <el-upload
           v-loading="avatarLoading"
           class="avatar-uploader"
           :action="uploadUrl"
           :headers="token"
           :show-file-list="false"
           :before-upload="
             () => {
               avatarLoading = true;
             }
           "
           :on-success="onAvatarSuccess"
           :on-error="onAvatarError"
           style="display: inline-block"
         >
           <el-image
             class="el-avatar el-avatar--square"
             :src="addForm.{{ initial_lower item.column_name }}"
             style="height: 90px; width: 90px; line-height: 90px"
           >
           </el-image>
           <div>
             <el-button plain style="width: 90px">
               <i class="el-icon-upload el-icon--left" />上传
             </el-button>
           </div>
         </el-upload>
      </el-form-item>
      {{~ else if item.input_type == "Input"  ~}}
        <el-form-item label="{{ item.column_comment }}" prop="{{ initial_lower item.column_name }}">
          <el-input v-model="addForm.{{ initial_lower item.column_name }}" auto-complete="off" />
        </el-form-item>
      {{~ end ~}}
      {{~ end ~}}
{{~ end ~}}
      </el-form>
      <template #footer>
        <el-button @click.native="addDialogFormVisible = false">取消</el-button>
        <my-confirm-button type="submit" :validate="addFormvalidate" :loading="addLoading" @click="onAddSubmit" />
      </template>
    </my-window>

    <!--编辑窗口-->
    <my-window
      v-if="checkPermission(['api:admin:{{ model.taxon | string.downcase }}:update'])"
      title="编辑"
      :visible.sync="editFormVisible"
      @close="closeEditForm"
    >
      <el-form
        ref="editForm"
        :model="editForm"
        :rules="editFormRules"
        label-width="80px"
        :inline="false"
      >
{{~ for item in   model.low_code_table_config_list ~}}
      {{~ if item.is_web_update ~}}
      {{~ if item.input_type == "Upload"  ~}}
      <el-form-item label="{{ item.column_comment }}" prop="{{ initial_lower item.column_name }}">
         <el-upload
           v-loading="avatarLoading"
           class="avatar-uploader"
           :action="uploadUrl"
           :headers="token"
           :show-file-list="false"
           :before-upload="
             () => {
               avatarLoading = true;
             }
           "
           :on-success="onAvatarSuccess"
           :on-error="onAvatarError"
           style="display: inline-block"
         >
           <el-image
             class="el-avatar el-avatar--square"
             :src="editForm.{{ initial_lower item.column_name }}"
             style="height: 90px; width: 90px; line-height: 90px"
           >
           </el-image>
           <div>
             <el-button plain style="width: 90px">
               <i class="el-icon-upload el-icon--left" />上传
             </el-button>
           </div>
         </el-upload>
      </el-form-item>
      {{~ else if item.input_type == "Input"  ~}}
        <el-form-item label="{{ item.column_comment }}" prop="{{ initial_lower item.column_name }}">
          <el-input v-model="editForm.{{ initial_lower item.column_name }}" auto-complete="off" />
        </el-form-item>
      {{~ end ~}}
      {{~ end ~}}
{{~ end ~}}
      </el-form>
      <template #footer>
        <el-button @click.native="editFormVisible = false">取消</el-button>
        <my-confirm-button type="submit" :validate="editFormvalidate" :loading="editLoading" @click="onEditSubmit" />
      </template>
    </my-window>

  </my-container>
</template>

<script>
import {  formatTime, listToTree, getTreeParents } from '@/utils'
import { getPageList, get, add, update, softDelete,batchSoftDelete } from '@/api/admin/{{ model.taxon | string.downcase }}'
import MyContainer from '@/components/my-container'
import MyConfirmButton from '@/components/my-confirm-button'
import MySearch from '@/components/my-search'
import MySearchWindow from '@/components/my-search-window'
import MyWindow from '@/components/my-window'

export default {
  name: '{{ model.taxon | string.downcase }}',
  components: { MyContainer, MyConfirmButton, MySearch, MySearchWindow, MyWindow },
  data() {
    return {
      // 高级查询字段
      fields: [
{{~ for item in   model.low_code_table_config_list ~}}
      {{~ if item.is_web_select ~}}
        { value: '{{ initial_lower item.column_name }}', label: '{{ item.column_comment }}', default: true },
      {{~ end ~}}
{{~ end ~}}
        { value: 'creationTime', label: '创建时间', type: 'date', operator: 'daterange',
          config: { type: 'daterange', format: 'yyyy-MM-dd', valueFormat: 'yyyy-MM-dd' }
        }
      ],
      dynamicFilter: null,
      pageList: [],
      total: 0,
      sels: [], // 列表选中列
      listLoading: false,
      pageLoading: false,
      editLoading: false,
      addLoading: false,
      deleteLoading: false,
      // 上传图片等待
      avatarLoading: false,
      // 添加界面
      addDialogFormVisible: false,
      // 编辑界面是否显示
      editFormVisible: false, 
      editFormRules: {
{{~ for item in   model.low_code_table_config_list ~}}
      {{~ if (!item.is_column_nullable && item.is_web_update) ~}}
         {{ initial_lower item.column_name }}functionModule: [{ required: true, message: '请输入{{ item.column_comment }}', trigger: 'blur' }],
      {{~ end ~}}
{{~ end ~}}
      },
      addFormRules: {
{{~ for item in   model.low_code_table_config_list ~}}
      {{~ if (!item.is_column_nullable && item.is_web_add) ~}}
         {{ initial_lower item.column_name }}functionModule: [{ required: true, message: '请输入{{ item.column_comment }}', trigger: 'blur' }],
      {{~ end ~}}
{{~ end ~}}
      },
      // 编辑界面数据
      editForm: {
        id: "",
{{~ for item in   model.low_code_table_config_list ~}}
      {{~ if item.is_web_update ~}}
        {{ initial_lower item.column_name }}: "",
      {{~ end ~}}
{{~ end ~}}
      },
      // 添加界面数据
      addForm: {
        id: "",
{{~ for item in   model.low_code_table_config_list ~}}
      {{~ if item.is_web_add ~}}
        {{ initial_lower item.column_name }}: "",
      {{~ end ~}}
{{~ end ~}}
      }
    }
  },
  async mounted() {
    await this.onGetPageList()
  },
  computed: {
    avatar() {
      const path = this.editForm.avatar
        ? process.env.VUE_APP_AVATAR_URL + this.editForm.avatar
        : this.avatarDefault;
      return path;
    },
    // 上传图片路径
    uploadUrl() {
      return process.env.VUE_APP_BASE_API + "/admin/user/avatarupload";
    },
    // 请求令牌
    token() {
      return { Authorization: "Bearer " + this.$store.getters.token };
    },
  },
  methods: {
    formatCreatedTime(row, column, time) {
      return formatTime(time, 'YYYY-MM-DD HH:mm')
    },
    // 查询
    onSearch(dynamicFilter) {
      this.$refs.pager.setPage(1)
      this.dynamicFilter = dynamicFilter
      this.onGetPageList()
    },
    // 显示添加界面
    onAdd() {
      this.addDialogFormVisible = true;
    },
    // 关闭添加
    closeAddForm() {
      this.$refs.addForm.resetFields()
      this.addDialogFormVisible = false
    },
    // 关闭编辑
    closeEditForm() {
      this.$refs.editForm.resetFields()
      this.editFormVisible = false
    },
    // 添加验证
    addFormvalidate() {
      let isValid = false
      this.$refs.addForm.validate(valid => {
        isValid = valid
      })
      return isValid
    },
    // 编辑验证
    editFormvalidate() {
      let isValid = false
      this.$refs.editForm.validate(valid => {
        isValid = valid
      })
      return isValid
    },
    // 删除验证
    deleteValidate(row) {
      let isValid = true
      return isValid
    },
    // 批量删除验证
    batchDeleteValidate() {
      let isValid = true
      return isValid
    },
    // 选择
    onSelsChange(sels) {
      this.sels = sels
    },
    // 上传成功
    onAvatarSuccess(res) {
      this.avatarLoading = false;
      if (!res?.code) {
        if (res.msg) {
          this.$message({
            message: res.msg,
            type: "error",
          });
        }
        return;
      }
{{~ for item in   model.low_code_table_config_list ~}}
      {{~ if item.input_type == "Upload"  ~}}
      this.editForm.{{ initial_lower item.column_name }} = res.data;
      this.addForm.{{ initial_lower item.column_name }} = res.data;
      {{~ end ~}}
{{~ end ~}}
    },
    // 上传失败
    onAvatarError(err, file) {
      this.avatarLoading = false;
      const res = err.message ? JSON.parse(err.message) : {};
      if (!res?.code) {
        if (res.msg) {
          this.$message({
            message: res.msg,
            type: "error",
          });
        }
      }
    },
    // 获取列表
    async onGetPageList() {
      var pager = this.$refs.pager.getPager()
      const params = {
        ...pager,
        dynamicFilter: this.dynamicFilter
      }
      this.listLoading = true
      const res = await getPageList(params)
      this.listLoading = false
      if (!res?.success) {
        return
      }
      this.total = res.data.total
      const data = res.data.list
      data.forEach(d => {
        d._loading = false
      })
      this.pageList = data
    },
    // 显示编辑界面
    async onEdit(index, row) {
      this.pageLoading = true
      const res = await get({ id: row.id })
      this.pageLoading = false
      if (res && res.success) {
        const data = res.data;
        this.editForm = data;
        this.editFormVisible = true;
      }
    },
    // 添加
    async onAddSubmit() {
      this.addLoading = true;
      const para = _.cloneDeep(this.addForm);
      const res = await add(para);
      this.addLoading = false;

      if (!res?.success) {
        return;
      }
      this.$message({
        message: this.$t("admin.addOk"),
        type: "success",
      });
      this.$refs["addForm"].resetFields();
      this.addDialogFormVisible = false;
      this.onGetPageList();
    },
    // 编辑
    async onEditSubmit() {
      this.editLoading = true
      const para = _.cloneDeep(this.editForm)
      const res = await update(para)
      this.editLoading = false

      if (!res?.success) {
        return
      }

      this.$message({
        message: this.$t('admin.updateOk'),
        type: 'success'
      })
      this.$refs['editForm'].resetFields()
      this.editFormVisible = false
      this.onGetPageList()
    },
    // 批量删除
    async onBatchDelete() {
      const para = { ids: [] };
      para.ids = this.sels.map((s) => {
        return s.id;
      });
      this.deleteLoading = true;
      const res = await batchSoftDelete(para.ids);
      this.deleteLoading = false;

      if (!res?.success) {
        return;
      }

      this.$message({
        message: this.$t("admin.batchDeleteOk"),
        type: "success",
      });

      this.onGetPageList();
    },
    // 删除
    async onDelete(index, row) {
      row._loading = true
      const para = { id: row.id }
      const res = await softDelete(para)
      row._loading = false
      if (!res?.success) {
        return
      }
      this.$message({
        message: this.$t('admin.deleteOk'),
        type: 'success'
      })
      this.onGetPageList()
    }
  }
}
</script>

<style lang="scss" scoped>
.my-search ::v-deep .el-input-group__prepend {
  background-color: #fff;
}
</style>
