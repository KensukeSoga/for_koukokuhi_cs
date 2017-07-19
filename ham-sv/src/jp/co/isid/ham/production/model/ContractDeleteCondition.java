package jp.co.isid.ham.production.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * �_����o�^��ʍ폜�{�^���������f�[�^�擾�̏����N���X
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/14 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class ContractDeleteCondition implements Serializable {
    /**
    *
    */
   private static final long serialVersionUID = 1L;

    /** �_����*/
   private String strCtrtKbn;
    /** �_��R�[�h*/
   private String strCtrtNo;

    /**
     * �_���ނ��擾����
     *
     * @return �_����
     */
    public String getStrCtrtKbn() {
        return strCtrtKbn;
    }

    /**
     * �_���ނ�ݒ肷��
     *
     * @param strCtrtKbn �_����
     */
    public void setStrCtrtKbn(String strCtrtKbn) {
        this.strCtrtKbn = strCtrtKbn;
    }

    /**
     * �_��R�[�h���擾����
     *
     * @return �_��R�[�h
     */
    public String getStrCtrtNo() {
        return strCtrtNo;
    }

    /**
     * �_��R�[�h��ݒ肷��
     *
     * @param strCtrtNo �_��R�[�h
     */
    public void setStrCtrtNo(String strCtrtNo) {
        this.strCtrtNo = strCtrtNo;
    }
}
