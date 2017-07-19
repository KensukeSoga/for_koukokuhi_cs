package jp.co.isid.ham.media.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
/**
 * <P>
 * �c�ƍ�Ƒ䒠���[�����N���X
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/20 HLC H.Watabe)<BR>
 * </P>
 * @author HLC H.Watabe
 */
@XmlRootElement(namespace = "http://model.media.ham.isid.co.jp/")
@XmlType(namespace = "http://model.media.ham.isid.co.jp/")
public class FindBillStatementCondition implements Serializable{

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** ���ԊJ�n */
    private String _kikanFrom = null;

    /** ���ԏI�� */
    private String _kikanTo = null;

    /** �S����ID */
    private String _hamid = null;

    /** �擾�t���O */
    private boolean _loadFlg;

    /** ��� */
    private String _functype;

    /** ���ID */
    private String _formID;

    /** ���[�U��� */
    private String _usertype = null;

    /** �ǃR�[�h */
    private String _kksikognzuntcd = null;

    /**
     * ���ԊJ�n���擾����
     *
     * @return ���ԊJ�n
     */
    public String getKikanFrom() {
        return _kikanFrom;
    }

    /**
     * ���ԊJ�n��ݒ肷��
     *
     * @param seikyuym ���ԊJ�n
     */
    public void setKikanFrom(String kikanFrom) {
        this._kikanFrom = kikanFrom;
    }

    /**
     * ���ԏI�����擾����
     *
     * @return ���ԏI��
     */
    public String getKikanTo() {
        return _kikanTo;
    }

    /**
     * ���ԏI����ݒ肷��
     *
     * @param seikyuym ���ԏI��
     */
    public void setKikanTo(String kikanTo) {
        this._kikanTo = kikanTo;
    }

    /**
     * �S����ID���擾����
     *
     * @return �S����ID
     */
    public String getHamid() {
        return _hamid;
    }

    /**
     * �S����ID��ݒ肷��
     *
     * @param hamid �S����ID
     */
    public void setHamid(String hamid) {
        this._hamid = hamid;
    }

    /**
     * �t�H�[�����[�h�t���O���擾
     * @return
     */
    public boolean getLoadFlg() {
        return _loadFlg;
    }

    /**
     * �t�H�[�����[�h�t���O��ݒ�
     * @param loadFlg
     */
    public void setLoadFlg(boolean loadFlg) {
        this._loadFlg = loadFlg;
    }

    /**
     * @return ���ID
     */
    public String getFormID() {
        return _formID;
    }

    /**
     * @param formID ���ID
     */
    public void setFormID(String formID) {
        _formID = formID;
    }

    /**
     * ��ʂ��擾����
     *
     * @return ���
     */
    public String getFuncType() {
        return _functype;
    }

    /**
     * ��ʂ�ݒ肷��
     *
     * @param funcid ���
     */
    public void setFuncType(String functype) {
        _functype = functype;
    }

    /**
     * ���[�U��ʂ��擾����
     *
     * @return ���[�U���
     */
    public String getUsertype() {
        return _usertype;
    }

    /**
     * ���[�U��ʂ�ݒ肷��
     *
     * @param usertype ���[�U���
     */
    public void setUsertype(String usertype) {
        this._usertype = usertype;
    }

    /**
     * �ǃR�[�h���擾����
     *
     * @return �ǃR�[�h
     */
    public String getKksikognzuntcd()
    {
        return _kksikognzuntcd;
    }

    /**
     * �ǃR�[�h��ݒ肷��
     *
     * @param kksikognzuntcd �ǃR�[�h
     */
    public void setKksikognzuntcd(String kksikognzuntcd)
    {
        this._kksikognzuntcd = kksikognzuntcd;
    }

}
