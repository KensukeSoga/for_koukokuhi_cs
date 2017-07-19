package jp.co.isid.ham.production.model;

import java.io.Serializable;
import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * �_����o�^��ʋN�����f�[�^�擾�̏����N���X
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/05 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class ContractRegisterCondition implements Serializable {
    /**
     *
     */
    private static final long serialVersionUID = 1L;

    /** �_����*/
    private String strCtrtKbn;
    /** �_��R�[�h*/
    private String strCtrtNo;
    /** �S����ID */
    private String _strHamid ;
    /** �@�\�R�[�h*/
    private List<String> _strSecurityCdList;
    /** �_����*/
    //private boolean strContract;
    /** ���ID */
    private String _formid = null;
    /** �S����ID */
    private String _hamid = null;
    /** ���[�U��� */
    private String _usertype = null;
    /** �ǃR�[�h */
    private String _kksikognzuntcd = null;

    /** �_����*/
    public void setStrCtrtKbn(String strCtrtKbn) {
        this.strCtrtKbn = strCtrtKbn;
    }
    public String getStrCtrtKbn() {
        return strCtrtKbn;
    }

    /** �_��R�[�h*/
    public void setStrCtrtNo(String strCtrtNo) {
        this.strCtrtNo = strCtrtNo;
    }
    public String getStrCtrtNo() {
        return strCtrtNo;
    }

    /**
     * �S����ID���擾����
     *
     * @return �S����ID
     */
    public String getStrHamid() {
        return _strHamid;
    }

    /**
     * �S����ID��ݒ肷��
     *
     * @param strHamid �S����ID
     */
    public void setStrHamid(String strHamid) {
        this._strHamid = strHamid;
    }

    /** �Z�L�����e�B�R�[�h*/
    public void setStrSecurityCdList(List<String> strSecurityCdList) {
        this._strSecurityCdList = strSecurityCdList;
    }
    public List<String> getStrSecurityCdList() {
        return _strSecurityCdList;
    }

//    /** �_����*/
//    public void setStrContract(boolean strContract) {
//        this.strContract = strContract;
//    }
//    public boolean getStrContract() {
//        return strContract;
//    }

    /**
     * ���ID���擾����
     *
     * @return ���ID
     */
    public String getFormid() {
        return _formid;
    }

    /**
     * ���ID��ݒ肷��
     *
     * @param formid ���ID
     */
    public void setFormid(String formid) {
        this._formid = formid;
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
