package jp.co.isid.ham.media.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.RepaVbjaMea10Irsk;
import jp.co.isid.ham.integ.tbl.RepaVbjaMea11DisplayIrsk;
import jp.co.isid.ham.integ.tbl.RepaVbjaMea12DisplayGyomKbn;
import jp.co.isid.ham.integ.tbl.Tbj02EigyoDaicho;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * �g�DVO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/02/19 HLC H.Watabe)<BR>
 * </P>
 * @author HLC H.Watabe
 */
@XmlRootElement(namespace = "http://model.media.ham.isid.co.jp/")
@XmlType(namespace = "http://model.media.ham.isid.co.jp/")
public class FindSocietyDataVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public FindSocietyDataVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance() {
        return new FindSocietyDataVO();
    }

    /**
     * �䒠No���擾����
     *
     * @return �䒠No
     */
    public String getDAICHONO() {
        return (String) get(Tbj02EigyoDaicho.DAICHONO);
    }

    /**
     * �䒠No��ݒ肷��
     *
     * @param val �䒠No
     */
    public void setDAICHONO(String val) {
        set(Tbj02EigyoDaicho.DAICHONO, val);
    }

    /**
     * IRSKCD���擾����
     *
     * @return IRSKCD
     */
    public String getIRSKCD() {
        return (String) get(RepaVbjaMea10Irsk.IRSKCD);
    }

    /**
     * IRSKCD��ݒ肷��
     *
     * @param val IRSKCD
     */
    public void setIRSKCD(String val) {
        set(RepaVbjaMea10Irsk.IRSKCD, val);
    }

    /**
     * IRSKSUBCD���擾����
     *
     * @return IRSKSUBCD
     */
    public String getIRSKSUBCD() {
        return (String) get(RepaVbjaMea10Irsk.IRSKSUBCD);
    }

    /**
     * IRSKSUBCD��ݒ肷��
     *
     * @param val IRSKSUBCD
     */
    public void setIRSKSUBCD(String val) {
        set(RepaVbjaMea10Irsk.IRSKSUBCD, val);
    }

    /**
     * DSIKKBNCD���擾����
     *
     * @return DSIKKBNCD
     */
    public String getDSIKKBNCD() {
        return (String) get(RepaVbjaMea11DisplayIrsk.DSIKKBNCD);
    }

    /**
     * DSIKKBNCD��ݒ肷��
     *
     * @param val DSIKKBNCD
     */
    public void setDSIKKBNCD(String val) {
        set(RepaVbjaMea11DisplayIrsk.DSIKKBNCD, val);
    }

    /**
     * GYOMKBNCD���擾����
     *
     * @return GYOMKBNCD
     */
    public String getGYOMKBNCD() {
        return (String) get(RepaVbjaMea12DisplayGyomKbn.GYOMKBNCD);
    }

    /**
     * GYOMKBNCD��ݒ肷��
     *
     * @param val GYOMKBNCD
     */
    public void setGYOMKBNCD(String val) {
        set(RepaVbjaMea12DisplayGyomKbn.GYOMKBNCD, val);
    }
}
