package jp.co.isid.ham.production.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Tbj27LogCrCreateDataVO;
import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Mbj16CrExpence;
import jp.co.isid.ham.integ.tbl.Mbj29SetteiKyk;
/**
 * <P>
 * �擾�����f�[�^���i�[����VO�N���X
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/06/24 �VHAM�`�[��)<BR>
 * </P>
 *
 * @author �VHAM�`�[��
 */

@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class FindChangeNoticeVO extends Tbj27LogCrCreateDataVO {

    /**
     *
     */
    private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public FindChangeNoticeVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance() {
        return new FindChangeNoticeVO();
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

    /**
     * ��ږ����擾����
     *
     * @return ��ږ�
     */
    public String getEXPNM() {
        return (String) get(Mbj16CrExpence.EXPNM);
    }

    /**
     * ��ږ���ݒ肷��
     *
     * @param val ��ږ�
     */
    public void setEXPNM(String val) {
        set(Mbj16CrExpence.EXPNM, val);
    }

    /**
     * ���[�����M�t���O���擾����
     *
     * @return ���[�����M�t���O
     */
    public String getMAILFLG() {
        return (String) get(Mbj29SetteiKyk.MAILFLG);
    }

    /**
     * ���[�����M�t���O��ݒ肷��
     *
     * @param val ���[�����M�t���O
     */
    public void setMAILFLG(String val) {
        set(Mbj29SetteiKyk.MAILFLG, val);
    }

}
