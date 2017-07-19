package jp.co.isid.ham.production.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Tbj20SozaiKanriListVO;

/**
 * <P>
 * �f�ވꗗ�@�o�^�p�ꗗ�f�[�^�ێ��N���X
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/05 �VHAM�`�[��)<BR>
 * �EJASRAC�Ή�(2015/11/19 HLC K.Soga)<BR>
 * </P>
 *
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class RegisterMaterialListUpdateVO extends Tbj20SozaiKanriListVO {

    private static final long serialVersionUID = 1L;

    /**
     * �ύX�O�Ԏ�R�[�h
     */
    private String _prevDCarCd = null;

    /** 2015/10/14 JASRAC�Ή� HLC K.Soga ADD Start */
    /**
     * �n��
     */
    private String _NoKbn = null;
    /** 2015/10/14 JASRAC�Ή� HLC K.Soga ADD End */

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance() {
        return new RegisterMaterialListUpdateVO();
    }

    /**
     * �ύX�O�Ԏ�R�[�h��ݒ肵�܂�
     * @param val
     */
    public void setPrevDCarCd(String val) {
        _prevDCarCd = val;
    }

    /**
     * �ύX�O�Ԏ�R�[�h���擾���܂�
     * @return
     */
    public String getPrevDCarCd() {
        return _prevDCarCd;
    }

    /** 2015/10/14 JASRAC�Ή� HLC K.Soga ADD Start */
    /**
     * �n�����擾����
     *
     * @return �n��
     */
    public String getNOKBN() {
        return _NoKbn;
    }

    /**
     * �n����ݒ肷��
     *
     * @param val �n��
     */
    public void setNOKBN(String val) {
        _NoKbn = val;
    }
    /** 2015/10/14 JASRAC�Ή� HLC K.Soga ADD End */
}