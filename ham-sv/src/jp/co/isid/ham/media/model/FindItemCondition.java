package jp.co.isid.ham.media.model;

import java.io.Serializable;

public class FindItemCondition implements Serializable{

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** ��� */
    private String _items;

    /** ���ԊJ�n */
    private String _kikanFrom;

    /** ���ԏI�� */
    private String _kikanTo;

    /** �Ɩ��敪 */
    private String _workFlg;

    /**
     * ��ڂ��擾
     * @return �˗���
     */
    public String getItems() {
        return _items;
    }

    /**
     * ��ڂ�ݒ�
     * @param requestDestination
     */
    public void setItems(String items) {
        this._items = items;
    }

    /**
     * ���ԊJ�n���擾
     * @return ����
     */
    public String getKikanFrom() {
        return _kikanFrom;
    }

    /**
     * ���ԊJ�n��ݒ�
     * @param kikan
     */
    public void setKikanFrom(String kikanFrom) {
        this._kikanFrom = kikanFrom;
    }

    /**
     * ���ԏI�����擾
     * @return ����
     */
    public String getKikanTo() {
        return _kikanTo;
    }

    /**
     * ���ԏI����ݒ�
     * @param kikan
     */
    public void setKikanTo(String kikanTo) {
        this._kikanTo = kikanTo;
    }

    /**
     * �Ɩ��敪���擾
     * @return �Ɩ��敪
     */
    public String getWorkFlg() {
        return _workFlg;
    }

    /**
     * �Ɩ��敪��ݒ�
     * @param workFlg
     */
    public void setWorkFlg(String workFlg) {
        this._workFlg = workFlg;
    }
}
