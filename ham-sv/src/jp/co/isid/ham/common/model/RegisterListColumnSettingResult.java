package jp.co.isid.ham.common.model;

import jp.co.isid.ham.model.AbstractServiceResult;

public class RegisterListColumnSettingResult extends AbstractServiceResult {

    /** List�����ł�Web�T�[�r�X�Ɍ��J����Ȃ��̂Ń_�~�[�v���p�e�B��ǉ� */
    private String _dummy;

    /**
     * List�����ł�Web�T�[�r�X�Ɍ��J����Ȃ��̂Ń_�~�[�v���p�e�B��ǉ�
     * @return String �_�~�[
     */
    public String getDummy() {
        return _dummy;
    }

    /**
     * List�����ł�Web�T�[�r�X�Ɍ��J����Ȃ��̂Ń_�~�[�v���p�e�B��ǉ�
     * @param dummy �_�~�[
     */
    public void setDummy(String dummy) {
        this._dummy = dummy;
    }
}
