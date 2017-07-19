package jp.co.isid.ham.production.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * �擾Condition
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/04/16 �X)<BR>
 * </P>
 * @author �X
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class FindJasracCondition implements Serializable
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �S����ID */
    private String _hamid;

    /** ���[�U��� */
    private String _usertype = null;

    /** ���ID */
    private String _formid;

    /** �ǃR�[�h */
    private String _kksikognzuntcd = null;

    /**
     * �S����ID���擾����
     *
     * @return �S����ID
     */
    public String getHamid()
    {
        return _hamid;
    }

    /**
     * �S����ID��ݒ肷��
     *
     * @param hamid �S����ID
     */
    public void setHamid(String hamid)
    {
        this._hamid = hamid;
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
     * ���ID���擾����
     *
     * @return ���ID
     */
    public String getFormid()
    {
        return _formid;
    }

    /**
     * ���ID��ݒ肷��
     *
     * @param formid ���ID
     */
    public void setFormid(String formid)
    {
        this._formid = formid;
    }

    /**
     * �ǃR�[�h���擾����
     *
     * @return �ǃR�[�h
     */
    public String getKksikognzuntcd() {
        return _kksikognzuntcd;
    }

    /**
     * �ǃR�[�h��ݒ肷��
     *
     * @param kksikognzuntcd �ǃR�[�h
     */
    public void setKksikognzuntcd(String kksikognzuntcd) {
        this._kksikognzuntcd = kksikognzuntcd;
    }

}
