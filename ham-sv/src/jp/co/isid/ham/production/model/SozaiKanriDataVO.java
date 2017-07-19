package jp.co.isid.ham.production.model;


import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Tbj18SozaiKanriDataVO;
import jp.co.isid.ham.integ.tbl.Mbj05Car;

/**
 * <P>
 * �f�ޓo�^�{����VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class SozaiKanriDataVO extends Tbj18SozaiKanriDataVO {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /* 2015/12/01 JASRAC�Ή� HLC S,Fujimoto ADD Start */
    /** �{�f�ށE���f�ރt���O */
    public static final String TEMPFLG = "TEMPFLG";
    /* 2015/12/01 JASRAC�Ή� HLC S.Fujimoto ADD End */

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public SozaiKanriDataVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance() {
        return new SozaiKanriDataVO();
    }

    /**
     * �Ԏ햼���擾����
     *
     * @return �Ԏ햼
     */
    public String getCARNM() {
        return (String) get(Mbj05Car.CARNM);
    }

    /**
     * �Ԏ햼��ݒ肷��
     *
     * @param val �Ԏ햼
     */
    public void setCARNM(String val) {
        set(Mbj05Car.CARNM, val);
    }

    /* 2015/11/30 JASRAC�Ή� HLC S.Fujimoto ADD Start */
    /**
     * �{�f�ށE���f�ރt���O���擾����
     * @return String �{�f�ށE���f�ރt���O
     */
    public String getTEMPFLG() {
        return (String) get(TEMPFLG);
    }

    /**
     * �{�f�ށE���f�ރt���O��ݒ肷��
     * @param val String �{�f�ށE���f�ރt���O
     */
    public void setTEMPFLG(String val) {
        set(TEMPFLG , val);
    }
    /* 2015/11/30 JASRAC�Ή� HLC S.Fujimoto ADD End */

}
